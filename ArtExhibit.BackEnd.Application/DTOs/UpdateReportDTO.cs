namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateReportDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
}
