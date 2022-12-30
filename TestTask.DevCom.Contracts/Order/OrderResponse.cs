namespace TestTask.DevCom.Contracts.Order;

public class OrderResponse
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate  { get; set; }
    public Decimal OrderCost { get; set; }
    public string ItemsDescription { get; set; } = null!;
    public string ShippingAddress  { get; set; } = null!;
}