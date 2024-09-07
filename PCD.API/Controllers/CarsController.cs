using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Infrastructure.DTOs.Cars;

namespace PCD.API.Controllers;
/// <summary>
/// API Controller for exposing endpoints about customers <see cref="Data.Entities.Car"/> data
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class CarsController : CustomControllerBase
{
    private readonly ICarsManagementService _service;
    private readonly HttpClient _tollClient;
    /// <summary>
    /// <see cref="CarsController"/> Constructor with required Dependancy injection.
    /// </summary>
    /// <param name="service">Car Service Dependancy.</param>
    /// <param name="factory">Http Client Factory Dependancy. Required for making calls to external APIs.</param>
    public CarsController(ICarsManagementService service, IHttpClientFactory factory)
    {
        _service = service;
        _tollClient = factory.CreateClient("TollApi");
    }
    /// <summary>
    /// Get Endpoint for retrieving all Cars
    /// </summary>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ListResponse<CarViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Get()
    {
        var response = await _service.GetAllCarsAsync();
        return Output(response);
    }
    /// <summary>
    /// Get Endpoint for retrieving Car's toll tax info by it's Id. The method makse a call to an external API.
    /// </summary>
    /// <param name="id">Car's unique Identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet("GetTollInfo/Car/{id}")]
    [ProducesResponseType(typeof(VignetteResponse), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var response = await _service.GetCarById(new(id));
        if (response.StatusCode != CustomStatusCode.Success)
        {
            return BadRequest();
        }
        if (response.Content is null)
        {
            return NotFound();
        }
        var httpResponse = await _tollClient.GetStringAsync($"{response.Content.CountryOfRegistration}/{response.Content.LicensePlateNumber}");
        var content = JsonConvert.DeserializeObject<VignetteResponse>(httpResponse);
        if (content is null)
        {
            return NotFound();
        }
        if (!content.Ok)
        {
            return BadRequest();
        }
        return Ok(content.Vignette);
    }
    /// <summary>
    /// Post Endpoint for creating a Car.
    /// </summary>
    /// <param name="model">Car's information passed with the body of the request.</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    /// <remarks>
    ///     POST api/Cars
    ///     {
    ///         
    ///     }
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse<CarViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Create([FromBody] CarAlterModel model)
    {
        var response = await _service.CreateCar(new(model));
        return Output(response);
    }
    /// <summary>
    /// Delete Endpoint for Removing a Car.
    /// </summary>
    /// <param name="id">Car's unique Identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpDelete("Car/{id}")]
    [ProducesResponseType(typeof(BaseResponse), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.DeleteCar(new(id));
        return Output(response);
    }
    /// <summary>
    /// Post Endpoint for Updating a Car's info.
    /// </summary>
    /// <param name="id">Car's unique Identifier</param>
    /// <param name="model">Car's information passed with the body of the request</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpPut("Car/{id}")]
    [ProducesResponseType(typeof(UpdateResponse<CarViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CarAlterModel model)
    {
        var response = await _service.UpdateCar(new(id, model));
        return Output(response);
    }
}
