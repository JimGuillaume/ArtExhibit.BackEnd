namespace ArtExhibit.BackEnd.Domain.Entities;

public class Bid
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public Sale Sale { get; set; } = null!;
    public int BuyerId { get; set; }
    public User Buyer { get; set; } = null!;
    public float Amount { get; set; }
    public DateTime PlacedAtUtc { get; set; }
}
