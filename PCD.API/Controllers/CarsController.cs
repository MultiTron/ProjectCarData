using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Infrastructure.DTOs.Cars;

namespace PCD.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : CustomControllerBase
{
    private readonly ICarsManagementService _service;
    private readonly HttpClient _tollClient;
    public CarsController(ICarsManagementService service, IHttpClientFactory factory)
    {
        _service = service;
        _tollClient = factory.CreateClient("TollApi");
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _service.GetAllCarsAsync();
        return Output(response);
    }
    [HttpGet("GetTollInfo/Car/{carId}")]
    public async Task<IActionResult> Get([FromRoute] int carId)
    {
        var response = await _service.GetCarById(new(carId));
        if (response.StatusCode != ApplicationServices.Messaging.StatusCode.Success)
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
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CarAlterModel model)
    {
        var response = await _service.CreateCar(new(model));
        return Output(response);
    }
    [HttpDelete("Car/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _service.DeleteCar(new(id));
        return Output(response);
    }
    [HttpPut("Car/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CarAlterModel model)
    {
        var response = await _service.UpdateCar(new(id, model));
        return Output(response);
    }
}
