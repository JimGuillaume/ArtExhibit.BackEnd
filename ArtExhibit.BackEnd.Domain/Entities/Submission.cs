namespace ArtExhibit.BackEnd.Domain.Entities;

public class Submission
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public DateOnly Date {  get; set; }
    public string Status { get; set; } = "Pending";
    public string RejectionReason {  get; set; } = string.Empty;
    public User User { get; set; }
    public Item Item { get; set; }
}