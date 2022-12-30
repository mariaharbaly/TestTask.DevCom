using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data.Abstracts;

public interface IOrderRepository
{
    Task<Order?> GetLastAsync(int userId);
    Task AddAsync(Order order);
    Task<Order[]> GetAsync(int userId);
    Task<Order?> GetByIdAsync(int id);
    void Delete(Order order);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}