using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IShipmentService
{
    Task<IEnumerable<ShipmentDTO>> GetAllShipmentAsync();
    Task<ShipmentDTO?> GetShipmentByIdAsync(int id);
    Task<ShipmentDTO?> AddShipmentAsync(CreateShipmentDTO shipmentDTO);
    Task UpdateShipmentAsync(UpdateShipmentDTO shipmentDTO);
    Task DeleteShipmentAsync(int id);
}
