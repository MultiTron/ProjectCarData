using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
using PCD.Infrastructure.DTOs.Users;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Response;

namespace PCD.API.Controllers;
/// <summary>
/// API Controller for exposing endpoints about customers <see cref="Data.Entities.User"/> data
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsersController : CustomControllerBase
{
    private readonly IUsersManagementService _service;
    /// <summary>
    /// <see cref="UsersController"/> Constructor with required Dependancy injection.
    /// </summary>
    /// <param name="service">User Service Dependancy.</param>
    public UsersController(IUsersManagementService service)
    {
        _service = service;
    }
    /// <summary>
    /// Get Endpoint for retrieving all Users
    /// </summary>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ListResponse<UserViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Get()
    {
        var response = await _service.GetAllUsers();
        return Output(response);
    }
    /// <summary>
    /// Post Endpoint for creating a User.
    /// </summary>
    /// <param name="model">User's information passed with the body of the request.</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    /// <remarks>
    ///     POST api/Users
    ///     {
    ///         
    ///     }
    /// </remarks>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateResponse<UserViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Create([FromBody] UserAlterModel model)
    {
        var response = await _service.CreateUser(new(model));
        return Output(response);
    }
    /// <summary>
    /// Delete Endpoint for Removing a User.
    /// </summary>
    /// <param name="id">User's unique Identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpDelete("User/{id}")]
    [ProducesResponseType(typeof(BaseResponse), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.DeleteUser(new(id));
        return Output(response);
    }
    /// <summary>
    /// Get Endpoint for retrieving a User by it's id
    /// </summary>
    /// <param name="id">User's unique identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet("User/{id}")]
    [ProducesResponseType(typeof(GetResponse<UserViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _service.GetUserById(new(id));
        return Output(response);
    }
    /// <summary>
    /// Get Endpoint for retrieving all Cars for one User
    /// </summary>
    /// <param name="id">User's unique identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet("User/{id}/Cars")]
    [ProducesResponseType(typeof(GetResponse<UserViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> GetCarsByUser([FromRoute] int id)
    {
        var response = await _service.GetCarsByUser(new(id));
        return Output(response);
    }
    /// <summary>
    /// Post Endpoint for Updating a User's info.
    /// </summary>
    /// <param name="id">User's unique Identifier</param>
    /// <param name="model">User's information passed with the body of the request</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpPut("User/{id}")]
    [ProducesResponseType(typeof(UpdateResponse<UserViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserAlterModel model)
    {
        var response = await _service.UpdateUser(new(id, model));
        return Output(response);
    }
    /// <summary>
    /// Get Endpoint for generating a JWT Token
    /// </summary>
    /// <param name="email">User's Email</param>
    /// <param name="password">User's password</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [AllowAnonymous]
    [HttpGet("[action]")]
    [ProducesResponseType(typeof(TokenResponse), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
    {
        var response = await _service.Authenticate(email, password);
        return Output(response);
    }
}
