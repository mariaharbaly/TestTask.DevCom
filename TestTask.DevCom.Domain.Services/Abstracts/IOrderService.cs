using TestTask.DevCom.Contracts.Order;

namespace TestTask.DevCom.Domain.Services.Abstracts;

public interface IOrderService
{
    Task<OrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest);
    Task<OrderResponse[]> GetOrdersAsync(int userId);
    Task<OrderResponse> UpdateOrderAsync(int id, UpdateOrderRequest updateOrderRequest);
    Task DeleteOrderAsync(int id);
}