using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : CustomControllerBase
{
    private readonly IUsersManagementService _service;

    public UsersController(IUsersManagementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _service.GetAllUsers();
        return Output(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserAlterModel model)
    {
        var response = await _service.CreateUser(new(model));
        return Output(response);
    }
    [HttpDelete("User/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.DeleteUser(new(id));
        return Output(response);
    }
    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _service.GetUserById(new(id));
        return Output(response);
    }
    [HttpGet("User/{id}/Cars")]
    public async Task<IActionResult> GetCarsByUser([FromRoute] int id)
    {
        var response = await _service.GetCarsByUser(new(id));
        return Output(response);
    }
    [HttpPut("User/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserAlterModel model)
    {
        var response = await _service.UpdateUser(new(id, model));
        return Output(response);
    }
    [AllowAnonymous]
    [HttpGet("Token")]
    public async Task<IActionResult> Token([FromQuery] string clientId, [FromQuery] string secret)
    {
        var response = await _service.Authenticate(clientId, secret);
        return Output(response);
    }
}
