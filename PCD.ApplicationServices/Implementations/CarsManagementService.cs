using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging.Cars.Request;
using PCD.ApplicationServices.Messaging.Cars.Response;
using PCD.Data;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Implementations
{
    public class CarsManagementService : BaseManagementService, ICarsManagementService
    {
        private readonly ApplicationContext _context;
        public CarsManagementService(ApplicationContext context, IMapper mapper, ILogger<CarsManagementService> logger) : base(mapper, logger)
        {
            _context = context;
        }

        public async Task<CreateCarResponse> CreateCar(CreateCarRequest request)
        {
            var responseCar = await _context.Cars.AddAsync(_mapper.Map<Car>(request.Car));
            var status = await _context.SaveChangesAsync();
            if (status > 0)
            {
                return new(_mapper.Map<CarViewModel>(responseCar.Entity));
            }
            else
            {
                return new() { StatusCode = Messaging.StatusCode.ClientError };
            }
        }

        public async Task<GetCarsResponse> GetAllCarsAsync()
        {
            var cars = new List<CarViewModel>();
            await _context.Cars.ForEachAsync(x => cars.Add(_mapper.Map<CarViewModel>(x)));
            return new(cars);
        }

        public async Task<GetCarResponse> GetCarById(int id)
            => new(_mapper.Map<CarViewModel>(await _context.Cars.FindAsync(id)));
    }
}
