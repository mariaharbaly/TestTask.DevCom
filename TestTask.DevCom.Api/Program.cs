using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.DevCom.Api.Middleware;
using TestTask.DevCom.Api.Validators;
using TestTask.DevCom.Contracts.Order;
using TestTask.DevCom.Contracts.User;
using TestTask.DevCom.Data;
using TestTask.DevCom.Data.Abstracts;
using TestTask.DevCom.Data.Repositories;
using TestTask.DevCom.Domain.Services;
using TestTask.DevCom.Domain.Services.Abstracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("TestTask.DevCom.Data")));
builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>()!);

var typeAdapterConfig = TypeAdapterConfig.GlobalSettings; 
typeAdapterConfig.Scan(typeof(UserService).Assembly);
var mapperConfig = new Mapper(typeAdapterConfig);
builder.Services.AddSingleton<IMapper>(mapperConfig);

    
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();
builder.Services.AddScoped<IValidator<CreateOrderRequest>, CreateOrderRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateOrderRequest>, UpdateOrderRequestValidator>();

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();
    
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.Run();
}
