namespace TestTask.DevCom.Contracts.Order;

public class UpdateOrderRequest
{
    public Decimal OrderCost { get; set; }
    public string ItemsDescription { get; set; } = null!;
    public string ShippingAddress  { get; set; } = null!;
}