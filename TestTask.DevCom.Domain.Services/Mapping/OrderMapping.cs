using Mapster;
using TestTask.DevCom.Contracts.Order;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Domain.Services.Mapping;

public class OrderMapping: IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, Order>();
        config.NewConfig<Order, OrderResponse>();
        config.NewConfig<UpdateOrderRequest, Order>();

    }
}