namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateItemReviewDTO
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public string Review { get; set; } = string.Empty;
}