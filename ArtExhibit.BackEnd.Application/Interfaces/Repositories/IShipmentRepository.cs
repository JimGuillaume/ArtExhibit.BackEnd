using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface IShipmentRepository
{
    Task<IEnumerable<Shipment>> GetAllAsync();

    Task<Shipment?> GetByIdAsync(int id);

    Task<Shipment?> AddAsync(Shipment shipment);

    Task UpdateAsync(Shipment shipment);

    Task DeleteAsync(int id);
}
