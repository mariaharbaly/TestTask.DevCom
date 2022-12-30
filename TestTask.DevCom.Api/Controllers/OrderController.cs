using Microsoft.AspNetCore.Mvc;
using TestTask.DevCom.Contracts.Order;
using TestTask.DevCom.Domain.Services.Abstracts;

namespace TestTask.DevCom.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(CreateOrderRequest createOrderRequest)
    {
        var order = await _orderService.CreateOrderAsync(createOrderRequest);
        return Ok(order);
    }
    
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get([FromRoute] int userId)
    {
        var orders = await _orderService.GetOrdersAsync(userId);
        return Ok(orders);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> Update([FromRoute] int id, UpdateOrderRequest updateOrderRequest)
    {
        var order = await _orderService.UpdateOrderAsync(id, updateOrderRequest);
        return Ok(order);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return Ok();
    }
}