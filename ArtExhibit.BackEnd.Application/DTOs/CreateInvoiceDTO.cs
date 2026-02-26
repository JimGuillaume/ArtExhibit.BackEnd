namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateInvoiceDTO
{
    public DateOnly Date { get; set; }
    public int OrderId { get; set; }
}