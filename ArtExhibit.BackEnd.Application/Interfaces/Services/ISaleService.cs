using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface ISaleService
{
    Task<IEnumerable<SaleDTO>> GetAllSaleAsync();
    Task<SaleDTO?> GetSaleByIdAsync(int id);
    Task<SaleDTO?> AddSaleAsync(CreateSaleDTO DTO);
    Task UpdateSaleAsync(UpdateSaleDTO saleDTO);
    Task DeleteSaleAsync(int id);
}