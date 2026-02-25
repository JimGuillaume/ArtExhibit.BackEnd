using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateOrderDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public float TotalPrice { get; set; } = 0f;
    public float Commission { get; set; } = 0f;
    public string OrderStatus { get; set; } = string.Empty;
}
