using Mapster;
using TestTask.DevCom.Contracts.User;
using TestTask.DevCom.Entities;

namespace TestTask.DevCom.Domain.Services.Mapping;

public class UserMapping: IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateUserRequest, User>();
        config.NewConfig<User, UserResponse>();
        config.NewConfig<UpdateUserRequest, User>();

    }
}