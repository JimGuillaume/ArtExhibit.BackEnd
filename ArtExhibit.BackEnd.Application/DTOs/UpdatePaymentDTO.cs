namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdatePaymentDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public float Amount { get; set; } = 0f;
    public string Status { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
}
