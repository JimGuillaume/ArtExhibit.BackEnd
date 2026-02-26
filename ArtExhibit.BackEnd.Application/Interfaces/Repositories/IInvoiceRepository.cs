using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync();

    Task<Invoice?> GetByIdAsync(int id);

    Task<Invoice?> AddAsync(Invoice invoice);

    Task UpdateAsync(Invoice invoice);

    Task DeleteAsync(int id);
}