using MapsterMapper;
using TestTask.DevCom.Common.Exceptions;
using TestTask.DevCom.Contracts.Order;
using TestTask.DevCom.Data.Abstracts;
using TestTask.DevCom.Domain.Services.Abstracts;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Domain.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, IOrderRepository orderRepository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }


    public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest)
    {
        var user = await _userRepository.GetByIdAsync(createOrderRequest.UserId);

        if (user is null)
            throw new NotFoundException($"User not found");
        
        var lastOrder = await _orderRepository.GetLastAsync(createOrderRequest.UserId);

        if (lastOrder is not null && Math.Abs(lastOrder.OrderDate.Subtract(DateTime.Now).TotalHours) <= 24)
        {
            throw new EntityAlreadyExistException($"Order can be created once per day");
        }
        
        var order = _mapper.Map<Order>(createOrderRequest);
        order.OrderDate = DateTime.Now;
        
        await _orderRepository.AddAsync(order);
        
        await _orderRepository.SaveChangesAsync();
            
        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<OrderResponse[]> GetOrdersAsync(int userId)
    {
        var orders = await _orderRepository.GetAsync(userId);
        
        return _mapper.Map<OrderResponse[]>(orders);
    }
    
    public async Task<OrderResponse> UpdateOrderAsync(int id, UpdateOrderRequest updateOrderRequest)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null)
            throw new NotFoundException("Order not found");
        
        _mapper.Map(updateOrderRequest, order);

        await _orderRepository.SaveChangesAsync();
        
        return _mapper.Map<OrderResponse>(order);
    }
    
    public async Task DeleteOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null)
            return;

        if (Math.Abs(order.OrderDate.Subtract(DateTime.Now).TotalHours) <= 24)
        {
            throw new InvalidOperationException("Order is assigned");
        }

        _orderRepository.Delete(order);

        await _orderRepository.SaveChangesAsync();
    }
}
