namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
    public int CategoryId { get; set; }
    public int UserId { get; set; }
}
