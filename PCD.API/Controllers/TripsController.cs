using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
using PCD.Infrastructure.DTOs.Trips;

namespace PCD.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TripsController : CustomControllerBase
{
    private readonly ITripsManagementService _service;

    public TripsController(ITripsManagementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _service.GetAllTrips();
        return Output(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TripAlterModel model)
    {
        var response = await _service.CreateTrip(new(model));
        return Output(response);
    }
    [HttpDelete("Trip/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.DeleteTrip(new(id));
        return Output(response);
    }
    [HttpGet("Trip/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _service.GetTripById(new(id));
        return Output(response);
    }
    [HttpPut("Trip/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TripAlterModel model)
    {
        var response = await _service.UpdateTrip(new(id, model));
        return Output(response);
    }

}
