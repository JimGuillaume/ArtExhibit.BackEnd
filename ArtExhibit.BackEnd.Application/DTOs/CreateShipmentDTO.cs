namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateShipmentDTO
{
    public int OrderId { get; set; }
    public string Carrier { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
}
