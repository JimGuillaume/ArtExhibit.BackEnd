namespace ArtExhibit.BackEnd.Domain.Entities;

public class ItemReview
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public string Review {  get; set; } = string.Empty;
}