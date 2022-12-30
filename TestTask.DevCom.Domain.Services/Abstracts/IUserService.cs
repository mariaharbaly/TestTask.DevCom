using TestTask.DevCom.Contracts.User;

namespace TestTask.DevCom.Domain.Services.Abstracts;

public interface IUserService
{
    Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest);
    Task<UserResponse> GetUserAsync(int id);
    Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest updateUserRequest);
    Task DeleteUserAsync(int id);
}