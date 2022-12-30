using Microsoft.EntityFrameworkCore;
using TestTask.DevCom.Data.Abstracts;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data;

public class DataContext: DbContext, IDataContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
        
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
        
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}