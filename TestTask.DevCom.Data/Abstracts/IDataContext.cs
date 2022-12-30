using Microsoft.EntityFrameworkCore;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data.Abstracts;

public interface IDataContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}