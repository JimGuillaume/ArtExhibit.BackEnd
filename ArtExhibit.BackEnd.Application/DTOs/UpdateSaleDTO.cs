namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateSaleDTO
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public float StartingPrice { get; set; } = 0.0f;
    public float FinalPrice { get; set; } = 0.0f;
    public string Status { get; set; } = string.Empty;

    //Item Ref
    public int ItemId { get; set; }

    //Buyer & Saler Ref
    public int BuyerId { get; set; }
    public int SellerId { get; set; }
}