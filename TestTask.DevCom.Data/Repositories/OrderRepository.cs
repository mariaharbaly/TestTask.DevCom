using Microsoft.EntityFrameworkCore;
using TestTask.DevCom.Data.Abstracts;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly IDataContext _dataContext;

    public OrderRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public Task<Order?> GetLastAsync(int userId)
        => _dataContext.Orders.FirstOrDefaultAsync(x => x.UserId == userId);
    
    public async Task AddAsync(Order order)
    =>  await _dataContext.Orders.AddAsync(order);
    
    public Task<Order[]> GetAsync(int userId) 
        => _dataContext.Orders.Where(x => x.UserId == userId).ToArrayAsync();

    public Task<Order?> GetByIdAsync(int id)
        => _dataContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
    
    public void Delete(Order order)
        => _dataContext.Orders.Remove(order);
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        =>  _dataContext.SaveChangesAsync(cancellationToken);

}
