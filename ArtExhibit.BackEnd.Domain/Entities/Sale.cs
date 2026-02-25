namespace ArtExhibit.BackEnd.Domain.Entities;

public class Sale
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public float StartingPrice { get; set; } = 0.0f;
    public float FinalPrice { get; set; } = 0.0f;
    public string Status { get; set; } = string.Empty;

    //Item Ref
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;

    //Buyer & Saler Ref
    public int BuyerId { get; set; }
    public User Buyer { get; set; } = null!;
    public int SellerId { get; set; }
    public User Seller { get; set; } = null!;
}