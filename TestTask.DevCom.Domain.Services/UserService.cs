using MapsterMapper;
using TestTask.DevCom.Common.Exceptions;
using TestTask.DevCom.Contracts.User;
using TestTask.DevCom.Data.Abstracts;
using TestTask.DevCom.Domain.Services.Abstracts;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest)
    {
        var existingUser = await _userRepository.GetByLoginAsync(createUserRequest.Login);

        if (existingUser is not null)
            throw new EntityAlreadyExistException($"User with login {existingUser.Login} already exist");
        
        var user = _mapper.Map<User>(createUserRequest);
        await _userRepository.AddAsync(user);
        
        await _userRepository.SaveChangesAsync();
            
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> GetUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            throw new NotFoundException("User not found");

        return _mapper.Map<UserResponse>(user);
    }
    
    public async Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest updateUserRequest)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            throw new NotFoundException("User not found");
        
        _mapper.Map(updateUserRequest, user);

        await _userRepository.SaveChangesAsync();
        
        return _mapper.Map<UserResponse>(user);
    }
    
    public async Task DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            return;
        
        var order = await _orderRepository.GetLastAsync(id);

        if (order is not null && Math.Abs(order.OrderDate.Subtract(DateTime.Now).TotalHours) <= 24)
        {
            throw new InvalidOperationException("User has assigned order");
        }

        _userRepository.Delete(user);

        await _userRepository.SaveChangesAsync();
    }
}