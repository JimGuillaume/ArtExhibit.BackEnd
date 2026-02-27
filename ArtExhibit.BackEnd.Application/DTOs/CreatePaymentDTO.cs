namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreatePaymentDTO
{
    public int OrderId { get; set; }
    public float Amount { get; set; } = 0f;
    public string PaymentMethod { get; set; } = string.Empty;
}
