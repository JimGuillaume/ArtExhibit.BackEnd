using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public float TotalPrice { get; set; } = 0f;
    public float Commission { get; set; } = 0f;
    public string OrderStatus { get; set; } = string.Empty;
}
