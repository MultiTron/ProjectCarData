using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
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
        return Determin(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserAlterModel model)
    {
        var response = await _service.CreateUser(new(model));
        return Determin(response);
    }
    [HttpDelete("User/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.DeleteUser(new(id));
        return Determin(response);
    }
    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _service.GetUserById(new(id));
        return Determin(response);
    }
    [HttpGet("User/{id}/Cars")]
    public async Task<IActionResult> GetCarsByUser([FromRoute] int id)
    {
        var response = await _service.GetCarsByUser(new(id));
        return Determin(response);
    }
    [HttpPut("User/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserAlterModel model)
    {
        var response = await _service.UpdateUser(new(id, model));
        return Determin(response);
    }
    private IActionResult Determin(BaseResponse response)
    {
        if (response.StatusCode == ApplicationServices.Messaging.StatusCode.Success)
        {
            return Ok(response);
        }
        return BadRequest();
    }
}
