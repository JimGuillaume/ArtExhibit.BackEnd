namespace ArtExhibit.BackEnd.Application.DTOs;

public class SubmissionDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; } = "Pending";
    public string RejectionReason { get; set; } = string.Empty;
}