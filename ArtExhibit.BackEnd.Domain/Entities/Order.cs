namespace ArtExhibit.BackEnd.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public float TotalPrice { get; set; } = 0f;
    public float Commission { get; set; } = 0f;
    public string OrderStatus { get; set; } = string.Empty;
}