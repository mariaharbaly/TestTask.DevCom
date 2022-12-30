using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId).ValueGeneratedOnAdd();
        builder.Property(u => u.Login).HasMaxLength(20);
        builder.HasIndex(u => u.Login).IsUnique();
        builder.Property(u => u.Password).HasMaxLength(50);
        builder.Property(u => u.FirstName).HasMaxLength(40);
        builder.Property(u => u.LastName).HasMaxLength(40);
        builder.Property(u => u.Gender).HasMaxLength(1);
        builder.HasMany(u => u.Orders).WithOne().HasForeignKey(x => x.UserId);

    }
}