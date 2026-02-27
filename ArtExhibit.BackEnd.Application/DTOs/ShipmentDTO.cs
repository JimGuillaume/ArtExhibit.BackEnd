namespace ArtExhibit.BackEnd.Application.DTOs;

public class ShipmentDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Carrier { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
