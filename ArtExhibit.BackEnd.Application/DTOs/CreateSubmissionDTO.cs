namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateSubmissionDTO
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public DateOnly Date { get; set; }
}