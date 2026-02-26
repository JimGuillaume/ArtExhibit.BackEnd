namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateInvoiceDTO
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public float Amount { get; set; } = 0f;
    public int OrderId { get; set; }
    public float OrderPrice { get; set; } = 0f;
    public float OrderComission { get; set; } = 0f;
}