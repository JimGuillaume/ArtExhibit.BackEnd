using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _repository;

    public ShipmentService(IShipmentRepository repository)
    {
        _repository = repository; 
    }

    private ShipmentDTO MapToDTO(Shipment shipment)
    {
        return new ShipmentDTO
        {
            Id = shipment.Id,
            OrderId = shipment.OrderId,
            Carrier = shipment.Carrier,
            TrackingNumber = shipment.TrackingNumber,
            Status = shipment.Status
        };
    }
    public async Task<IEnumerable<ShipmentDTO>> GetAllShipmentAsync()
    {
        var shipments = await _repository.GetAllAsync();
        var dtos = new List<ShipmentDTO>();
        foreach (var shipment in shipments)
        {
            dtos.Add(MapToDTO(shipment)); 
        }
        return dtos;
    }
    public async Task<ShipmentDTO?> GetShipmentByIdAsync(int id)
    {
        var shipment = await _repository.GetByIdAsync(id);
        if (shipment != null)
            return MapToDTO(shipment);
        return null;
    }
    public async Task<ShipmentDTO?> AddShipmentAsync(CreateShipmentDTO shipmentDTO)
    {
        var shipment = new Shipment
        {
            OrderId = shipmentDTO.OrderId,
            Carrier = shipmentDTO.Carrier,
            TrackingNumber = shipmentDTO.TrackingNumber,
            Status = "Pending"
        };
        var newShipment = await _repository.AddAsync(shipment);
        if (newShipment != null)
            return MapToDTO(newShipment);
        return null;
    }
    public async Task UpdateShipmentAsync(UpdateShipmentDTO shipmentDTO)
    {
        var shipment = await _repository.GetByIdAsync(shipmentDTO.Id);
        if (shipment == null) throw new Exception("Shipment not found");
        shipment.Id = shipmentDTO.Id;
        shipment.OrderId = shipmentDTO.OrderId;
        shipment.Carrier = shipmentDTO.Carrier;
        shipment.TrackingNumber = shipmentDTO.TrackingNumber;
        shipment.Status = shipmentDTO.Status;

        await _repository.UpdateAsync(shipment);
    }
    public async Task DeleteShipmentAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
