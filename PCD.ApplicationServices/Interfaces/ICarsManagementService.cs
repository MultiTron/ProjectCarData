using PCD.ApplicationServices.Messaging;
using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Interfaces;

public interface ICarsManagementService
{
    public Task<ListResponse<CarViewModel>> GetAllCarsAsync();
    public Task<CreateResponse<CarViewModel>> CreateCar(CreateRequest<CarAlterModel> request);
    public Task<GetResponse<CarViewModel>> GetCarById(IdRequest request);
    public Task<BaseResponse> DeleteCar(IdRequest request);
    public Task<UpdateResponse<CarViewModel>> UpdateCar(UpdateRequest<CarAlterModel> request);
}
