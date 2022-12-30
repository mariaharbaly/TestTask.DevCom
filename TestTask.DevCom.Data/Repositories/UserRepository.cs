using Microsoft.EntityFrameworkCore;
using TestTask.DevCom.Data.Abstracts;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDataContext _dataContext;

    public UserRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(User user)
    => await _dataContext.Users.AddAsync(user);
    
    public Task<User?> GetByLoginAsync(string login)
        => _dataContext.Users.FirstOrDefaultAsync(x => x.Login == login);

    public Task<User?> GetByIdAsync(int id)
        => _dataContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

    public void Delete(User user)
        => _dataContext.Users.Remove(user);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dataContext.SaveChangesAsync(cancellationToken);
}