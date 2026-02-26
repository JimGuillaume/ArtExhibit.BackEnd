namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateReportDTO
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
}