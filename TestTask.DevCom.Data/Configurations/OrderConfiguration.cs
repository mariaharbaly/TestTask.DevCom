using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data.Configurations;

internal class OrderConfiguration: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.OrderId);
        builder.Property(p => p.OrderId).ValueGeneratedOnAdd();
        builder.Property(u => u.ItemsDescription ).HasMaxLength(1000);
        builder.Property(u => u.ShippingAddress ).HasMaxLength(1000);
        builder.Property(u => u.OrderCost ).HasColumnType("money");
    }
}