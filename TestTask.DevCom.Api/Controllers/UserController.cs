using Microsoft.AspNetCore.Mvc;
using TestTask.DevCom.Contracts.User;
using TestTask.DevCom.Domain.Services.Abstracts;

namespace TestTask.DevCom.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> Create(CreateUserRequest createUserRequest)
    {
        var user = await _userService.CreateUserAsync(createUserRequest);
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get([FromRoute] int id)
    {
        var user = await _userService.GetUserAsync(id);
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> Update([FromRoute] int id, UpdateUserRequest updateUserRequest)
    {
        var user = await _userService.UpdateUserAsync(id, updateUserRequest);
        return Ok(user);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok();
    }
}
