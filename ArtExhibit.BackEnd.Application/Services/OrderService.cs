using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class OrderService : IOrderService
{
    private IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    private OrderDTO MapToDTO(Order order)
    {
        return new OrderDTO
        {
            Id = order.Id,
            UserId = order.UserId,
            // si Coté gauche == Null alors renvoie string.empty
            UserName = order.User?.UserName ?? string.Empty,
            TotalPrice = order.TotalPrice,
            Commission = order.Commission,
            OrderStatus = order.OrderStatus
        };
    }
    public async Task<IEnumerable<OrderDTO>> GetAllOrderAsync()
    {
        var orders = await _repository.GetAllAsync();
        var dtos = new List<OrderDTO>();
        foreach (var order in orders)
        {
            dtos.Add(MapToDTO(order));
        }
        return dtos;
    }
    public async Task<OrderDTO?> GetOrderByIdAsync(int id)
    {
        var order = await _repository.GetByIdAsync(id);
        if (order == null)
            return null;
        return MapToDTO(order);
    }

    public async Task<OrderDTO?> AddOrderAsync(CreateOrderDTO orderDTO)
    {
        var order = new Order
        {
            UserId = orderDTO.UserId,
            TotalPrice = orderDTO.TotalPrice,
            Commission = orderDTO.Commission,
            OrderStatus = orderDTO.OrderStatus

        };
        var neworder = await _repository.AddAsync(order);
        if (neworder != null)
        {
            var orderwithrelation = await _repository.GetByIdAsync(neworder.Id);
            if (orderwithrelation != null)
                return MapToDTO(orderwithrelation);
        }
        return null;
    }

    public async Task UpdateOrderAsync(UpdateOrderDTO orderDTO)
    {
        var order = await _repository.GetByIdAsync(orderDTO.Id);
        if (order == null) throw new Exception("Order not found");

        order.UserId = orderDTO.UserId;
        order.TotalPrice = orderDTO.TotalPrice;
        order.Commission = orderDTO.Commission;
        order.OrderStatus = orderDTO.OrderStatus;

        await _repository.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}