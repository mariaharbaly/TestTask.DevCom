namespace TestTask.DevCom.Contracts.Order;

public class CreateOrderRequest
{
    public int UserId { get; set; }
    public Decimal OrderCost { get; set; }
    public string ItemsDescription { get; set; } = null!;
    public string ShippingAddress  { get; set; } = null!;
}