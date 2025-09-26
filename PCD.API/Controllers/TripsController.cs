using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
using PCD.Infrastructure.DTOs.Trips;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Response;

namespace PCD.API.Controllers;

/// <summary>
/// API Controller for exposing endpoints about customers <see cref="Data.Entities.Trip"/> data
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TripsController : CustomControllerBase
{
    private readonly ITripsManagementService _service;
    /// <summary>
    /// <see cref="TripsController"/> Constructor with required Dependancy injection.
    /// </summary>
    /// <param name="service">Trip Service Dependancy.</param>
    public TripsController(ITripsManagementService service)
    {
        _service = service;
    }
    /// <summary>
    /// Get Endpoint for retrieving all Trips
    /// </summary>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ListResponse<TripViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Get()
    {
        var response = await _service.GetAllTrips();
        return Output(response);
    }
    /// <summary>
    /// Post Endpoint for creating a Trip.
    /// </summary>
    /// <param name="model">Trip's information passed with the body of the request.</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    /// <remarks>
    ///     POST api/Trips
    ///     {
    ///         
    ///     }
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse<TripViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Create([FromBody] TripAlterModel model)
    {
        var response = await _service.CreateTrip(new(model));
        return Output(response);
    }
    /// <summary>
    /// Delete Endpoint for Removing a Trip.
    /// </summary>
    /// <param name="id">Trip's unique Identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpDelete("Trip/{id}")]
    [ProducesResponseType(typeof(BaseResponse), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var response = await _service.DeleteTrip(new(id));
        return Output(response);
    }
    /// <summary>
    /// Get Endpoint for retrieving a Trip by it's id
    /// </summary>
    /// <param name="id">Trip's unique identifier</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpGet("Trip/{id}")]
    [ProducesResponseType(typeof(GetResponse<TripViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _service.GetTripById(new(id));
        return Output(response);
    }
    /// <summary>
    /// Post Endpoint for Updating a Trip's info.
    /// </summary>
    /// <param name="id">Trip's unique Identifier</param>
    /// <param name="model">Trip's information passed with the body of the request</param>
    /// <returns>Asyncronous Task which represents an IActionResult. The IActionResult contains the response from the service layer.</returns>
    [HttpPut("Trip/{id}")]
    [ProducesResponseType(typeof(UpdateResponse<TripViewModel>), (int)CustomStatusCode.Success)]
    [ProducesResponseType((int)CustomStatusCode.ClientError)]
    [ProducesResponseType((int)CustomStatusCode.Unauthorized)]
    [ProducesResponseType((int)CustomStatusCode.NotFound)]
    [ProducesResponseType((int)CustomStatusCode.ServerError)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TripAlterModel model)
    {
        var response = await _service.UpdateTrip(new(id, model));
        return Output(response);
    }

}
