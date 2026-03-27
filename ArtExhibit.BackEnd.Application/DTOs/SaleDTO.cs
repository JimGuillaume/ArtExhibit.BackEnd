using System.Text.Json.Serialization;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class SaleDTO
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public float StartingPrice { get; set; } = 0.0f;

    [JsonPropertyName("amount")]
    public float FinalPrice { get; set; } = 0.0f;
    public string Status { get; set; } = string.Empty;

    //Item Ref
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;

    //Buyer & Saler Ref
    public int BuyerId { get; set; }
    public string BuyerUserName { get; set; } = string.Empty;

    public int SellerId { get; set; }
    public string SellerUserName { get; set; } = string.Empty;
}