namespace ArtExhibit.BackEnd.Domain.Entities;

public class Shipment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Carrier { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public Order Order { get; set; }
}
