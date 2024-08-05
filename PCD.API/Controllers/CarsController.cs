using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Interfaces;
using PCD.Infrastructure.DTOs.Cars;

namespace PCD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsManagementService _service;
        public CarsController(ICarsManagementService service)
        {
            _service = service;
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
