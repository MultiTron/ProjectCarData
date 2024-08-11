using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging.Cars.Response;
using PCD.Infrastructure.DTOs.Cars;

namespace PCD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
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
            if (response.StatusCode == ApplicationServices.Messaging.StatusCode.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpGet("GetTollInfo/Car/{carId}")]
        public async Task<IActionResult> Get([FromRoute] int carId)
        {
            var response = await _service.GetCarById(carId);
            if (response.StatusCode != ApplicationServices.Messaging.StatusCode.Success)
            {
                return BadRequest();
            }
            if (response.Car is null)
            {
                return NotFound();
            }
            var httpResponse = await _tollClient.GetStringAsync($"{response.Car.CountryOfRegistration}/{response.Car.LicensePlateNumber}");
            var content = JsonConvert.DeserializeObject<VignetteResponse>(httpResponse);
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
            if (response.StatusCode == ApplicationServices.Messaging.StatusCode.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
