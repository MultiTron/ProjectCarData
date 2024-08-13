using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
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
        if (response.StatusCode == ApplicationServices.Messaging.StatusCode.Success)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserAlterModel model)
    {
        var response = await _service.CreateUser(new(model));
        if (response.StatusCode == ApplicationServices.Messaging.StatusCode.Success)
        {
            return Ok(response);
        }
        return BadRequest();
    }
}
