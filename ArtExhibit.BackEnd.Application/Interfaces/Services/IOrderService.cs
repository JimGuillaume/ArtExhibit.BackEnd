using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrderAsync();
    Task<OrderDTO?> GetOrderByIdAsync(int id);
    Task<OrderDTO?> AddOrderAsync(CreateOrderDTO orderDTO);
    Task UpdateOrderAsync(UpdateOrderDTO orderDTO);
    Task DeleteOrderAsync(int id);
}