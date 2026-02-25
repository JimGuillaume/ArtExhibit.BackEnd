namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateSaleDTO
{
    public DateOnly StartDate { get; set; }
    public float StartingPrice { get; set; } = 0.0f;
    public string Status { get; set; } = "Active";
    public int ItemId { get; set; }
    public int SellerId { get; set; }
}
