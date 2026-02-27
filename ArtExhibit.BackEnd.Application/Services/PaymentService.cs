using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository; 
    }

    private PaymentDTO MapToDTO(Payment payment)
    {
        return new PaymentDTO
        {
            Id = payment.Id,
            OrderId = payment.OrderId,
            Amount = payment.Amount,
            Status = payment.Status,
            PaymentMethod = payment.PaymentMethod
        };
    }
    public async Task<IEnumerable<PaymentDTO>> GetAllPaymentAsync()
    {
        var payments = await _repository.GetAllAsync();
        var dtos = new List<PaymentDTO>();
        foreach (var payment in payments)
        {
            dtos.Add(MapToDTO(payment)); 
        }
        return dtos;
    }
    public async Task<PaymentDTO?> GetPaymentByIdAsync(int id)
    {
        var payment = await _repository.GetByIdAsync(id);
        if (payment != null)
            return MapToDTO(payment);
        return null;
    }
    public async Task<PaymentDTO?> AddPaymentAsync(CreatePaymentDTO paymentDTO)
    {
        var payment = new Payment
        {
            OrderId = paymentDTO.OrderId,
            Amount = paymentDTO.Amount,
            PaymentMethod = paymentDTO.PaymentMethod,
            Status = "Pending"
        };
        var newpayment = await _repository.AddAsync(payment);
        if (newpayment != null)
            return MapToDTO(newpayment);
        return null;
    }
    public async Task UpdatePaymentAsync(UpdatePaymentDTO paymentDTO)
    {
        var payment = await _repository.GetByIdAsync(paymentDTO.Id);
        if (payment == null) throw new Exception("Payment not found");
        payment.Id = paymentDTO.Id;
        payment.OrderId = paymentDTO.OrderId;
        payment.Amount = paymentDTO.Amount;
        payment.Status = paymentDTO.Status;
        payment.PaymentMethod = paymentDTO.PaymentMethod;

        await _repository.UpdateAsync(payment);
    }
    public async Task DeletePaymentAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
