using PCD.Infrastructure.DTOs.Cars;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Request;
using PCD.Infrastructure.Messaging.Response;

namespace PCD.ApplicationServices.Interfaces;

public interface ICarsManagementService
{
    public Task<ListResponse<CarViewModel>> GetAllCarsAsync();
    public Task<CreateResponse<CarViewModel>> CreateCar(CreateRequest<CarAlterModel> request);
    public Task<GetResponse<CarViewModel>> GetCarById(IdRequest request);
    public Task<BaseResponse> DeleteCar(IdRequest request);
    public Task<UpdateResponse<CarViewModel>> UpdateCar(UpdateRequest<CarAlterModel> request);
}
