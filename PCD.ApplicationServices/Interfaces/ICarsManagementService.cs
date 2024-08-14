using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;

namespace PCD.ApplicationServices.Interfaces;

public interface ICarsManagementService
{
    public Task<ListResponse> GetAllCarsAsync();
    public Task<CreateResponse> CreateCar(CreateCarRequest request);
    public Task<GetResponse> GetCarById(int id);
}
