using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;
using System.Security.Cryptography;

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
            SellerUserName = sale.Seller.UserName
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
        var sale = new Sale
        {
            StartDate = DTO.StartDate,
            StartingPrice = DTO.StartingPrice,
            Status = DTO.Status,
            ItemId = DTO.ItemId,
            SellerId= DTO.SellerId,
        };
        var newsale = await _repository.AddAsync(sale);
        if (newsale != null)
            return MapToDTO(sale);
        return null;
    }

    public async Task UpdateSaleAsync(UpdateSaleDTO saleDTO)
    {
        var sale = await _repository.GetByIdAsync(saleDTO.Id);
        if (sale == null) throw new Exception("Sale not found");

        sale.StartDate = saleDTO.StartDate;
        sale.EndDate = saleDTO.StartDate;
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
}