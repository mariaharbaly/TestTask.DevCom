namespace TestTask.DevCom.Entities;

public class Order : IEntity
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate  { get; set; }
    public decimal OrderCost { get; set; }
    public string ItemsDescription { get; set; } = null!;
    public string ShippingAddress  { get; set; } = null!;
}