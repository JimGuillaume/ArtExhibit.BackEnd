namespace ArtExhibit.BackEnd.Application.DTOs;

public class BidDTO
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int BuyerId { get; set; }
    public string BuyerUserName { get; set; } = string.Empty;
    public float Amount { get; set; }
    public DateTime PlacedAtUtc { get; set; }
}
