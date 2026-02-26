namespace ArtExhibit.BackEnd.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }
    public DateOnly Date {  get; set; }
    public float Amount { get; set; } = 0f;
    public int OrderId { get; set; }
    public Order Order { get; set; }
}