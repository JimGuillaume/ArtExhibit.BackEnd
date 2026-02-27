using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDTO>> GetAllPaymentAsync();
    Task<PaymentDTO?> GetPaymentByIdAsync(int id);
    Task<PaymentDTO?> AddPaymentAsync(CreatePaymentDTO paymentDTO);
    Task UpdatePaymentAsync(UpdatePaymentDTO paymentDTO);
    Task DeletePaymentAsync(int id);
}
