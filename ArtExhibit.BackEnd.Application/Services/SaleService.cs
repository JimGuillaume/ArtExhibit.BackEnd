using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _repository;

    public SaleService(ISaleRepository repository)
    {
        _repository = repository;
    }

    private SaleDTO MapToDTO(Sale sale)
    {
        return new SaleDTO
        {
            Id = sale.Id,
            StartDate = sale.StartDate,
            EndDate = sale.EndDate,
            StartingPrice = sale.StartingPrice,
            FinalPrice = sale.FinalPrice,
            Status = sale.Status,
            ItemId = sale.ItemId,
            ItemName = sale.Item.Name,
            BuyerId = sale.BuyerId,
            BuyerUserName = sale.Buyer.UserName,
            SellerId = sale.SellerId,
            SellerUserName = sale.Seller.UserName,
        };
    }

    private static BidDTO MapBidToDTO(Bid bid)
    {
        return new BidDTO
        {
            Id = bid.Id,
            SaleId = bid.SaleId,
            BuyerId = bid.BuyerId,
            BuyerUserName = bid.Buyer.UserName,
            Amount = bid.Amount,
            PlacedAtUtc = bid.PlacedAtUtc
        };
    }

    public async Task<IEnumerable<SaleDTO>> GetAllSaleAsync()
    {
        var sales = await _repository.GetAllAsync();
        var dtos = new List<SaleDTO>();
        foreach (var sale in sales)
        {
            dtos.Add(MapToDTO(sale));
        }
        return dtos;
    }

    public async Task<SaleDTO?> GetSaleByIdAsync(int id)
    {
        var sale = await _repository.GetByIdAsync(id);
        if (sale == null)
            return null;
        return MapToDTO(sale);
    }

    public async Task<SaleDTO?> AddSaleAsync(CreateSaleDTO DTO)
    {
        var startUtc = EnsureUtc(DTO.StartDate);
        var endUtc = EnsureUtc(DTO.EndDate);

        if (endUtc <= startUtc)
            throw new ArgumentException("End date must be greater than start date.");

        var sale = new Sale
        {
            StartDate = startUtc,
            EndDate = endUtc,
            StartingPrice = DTO.StartingPrice,
            Status = DTO.Status,
            ItemId = DTO.ItemId,
            SellerId = DTO.SellerId
        };

        var newSale = await _repository.AddAsync(sale);
        if (newSale != null)
            return MapToDTO(newSale);

        return null;
    }

    public async Task UpdateSaleAsync(UpdateSaleDTO saleDTO)
    {
        var sale = await _repository.GetByIdAsync(saleDTO.Id);
        if (sale == null) throw new Exception("Sale not found");

        var startUtc = EnsureUtc(saleDTO.StartDate);
        var endUtc = EnsureUtc(saleDTO.EndDate);

        if (endUtc <= startUtc)
            throw new ArgumentException("End date must be greater than start date.");

        sale.StartDate = startUtc;
        sale.EndDate = endUtc;
        sale.StartingPrice = saleDTO.StartingPrice;
        sale.FinalPrice = saleDTO.FinalPrice;
        sale.Status = saleDTO.Status;
        sale.ItemId = saleDTO.ItemId;
        sale.BuyerId = saleDTO.BuyerId;
        sale.SellerId = saleDTO.SellerId;

        await _repository.UpdateAsync(sale);
    }

    public async Task DeleteSaleAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<SaleDTO> PlaceBidAsync(int saleId, PlaceBidDTO bidDTO)
    {
        var sale = await _repository.GetByIdAsync(saleId);
        if (sale == null)
            throw new KeyNotFoundException("Sale not found.");

        if (!string.Equals(sale.Status, "Active", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Bids are only allowed on active sales.");

        var nowUtc = DateTime.UtcNow;
        if (sale.EndDate <= nowUtc)
            throw new InvalidOperationException("This auction has already ended.");

        var currentPrice = sale.FinalPrice > 0 ? sale.FinalPrice : sale.StartingPrice;
        if (bidDTO.BidAmount <= currentPrice)
            throw new ArgumentException("Bid amount must be greater than current price.");

        var bid = new Bid
        {
            SaleId = saleId,
            BuyerId = bidDTO.BuyerId,
            Amount = bidDTO.BidAmount,
            PlacedAtUtc = nowUtc
        };

        await _repository.AddBidAsync(bid);

        sale.BuyerId = bidDTO.BuyerId;
        sale.FinalPrice = bidDTO.BidAmount;

        ApplyAntiSniping(sale, nowUtc);

        await _repository.UpdateAsync(sale);

        var updatedSale = await _repository.GetByIdAsync(saleId) ?? sale;
        return MapToDTO(updatedSale);
    }

    public async Task<IEnumerable<BidDTO>> GetBidsBySaleIdAsync(int saleId)
    {
        var sale = await _repository.GetByIdAsync(saleId);
        if (sale == null)
            throw new KeyNotFoundException("Sale not found.");

        var bids = await _repository.GetBidsBySaleIdAsync(saleId);
        return bids.Select(MapBidToDTO);
    }

    private static void ApplyAntiSniping(Sale sale, DateTime bidTimeUtc)
    {
        var triggerWindow = TimeSpan.FromMinutes(5);
        var extension = TimeSpan.FromMinutes(5);

        var timeRemaining = sale.EndDate - bidTimeUtc;
        if (timeRemaining <= triggerWindow)
        {
            sale.EndDate = sale.EndDate.Add(extension);
        }
    }

    private static DateTime EnsureUtc(DateTime value)
    {
        return value.Kind switch
        {
            DateTimeKind.Utc => value,
            DateTimeKind.Local => value.ToUniversalTime(),
            DateTimeKind.Unspecified => DateTime.SpecifyKind(value, DateTimeKind.Utc),
            _ => value
        };
    }
}