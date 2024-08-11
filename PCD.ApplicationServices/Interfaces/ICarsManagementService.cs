using PCD.ApplicationServices.Messaging.Cars.Request;
using PCD.ApplicationServices.Messaging.Cars.Response;

namespace PCD.ApplicationServices.Interfaces
{
    public interface ICarsManagementService
    {
        public Task<GetCarsResponse> GetAllCarsAsync();
        public Task<CreateCarResponse> CreateCar(CreateCarRequest request);
        public Task<GetCarResponse> GetCarById(int id);
    }
}
