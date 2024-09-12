using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Cars;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Request;
using PCD.Infrastructure.Messaging.Response;
using PCD.Repository.Interfaces;

namespace PCD.ApplicationServices.Implementations;

public class CarsManagementService : BaseManagementService, ICarsManagementService
{
    private readonly IUnitOfWork _unitOfWork;
    public CarsManagementService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CarsManagementService> logger) : base(mapper, logger)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateResponse<CarViewModel>> CreateCar(CreateRequest<CarAlterModel> request)
    {
        var responseCar = await _unitOfWork.Cars.Save(_mapper.Map<Car>(request.Content));
        var status = await _unitOfWork.SaveChangesAsync();
        if (status > 0)
        {
            return new(_mapper.Map<CarViewModel>(responseCar));
        }
        else
        {
            return new() { StatusCode = CustomStatusCode.ClientError };
        }
    }

    public async Task<ListResponse<CarViewModel>> GetAllCarsAsync()
        => new((await _unitOfWork.Cars.GetAll()).Select(_mapper.Map<CarViewModel>).ToList());

    public async Task<GetResponse<CarViewModel>> GetCarById(IdRequest request)
        => new(_mapper.Map<CarViewModel>(await _unitOfWork.Cars.GetById(request.Id)));
    public async Task<BaseResponse> DeleteCar(IdRequest request)
    {
        try
        {
            await Task.Run(() => { _unitOfWork.Cars.Delete(request.Id); });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete Error...");
            return new(CustomStatusCode.ServerError);
        }
        return new();
    }

    public async Task<UpdateResponse<CarViewModel>> UpdateCar(UpdateRequest<CarAlterModel> request)
    {
        var entity = _mapper.Map<Car>(request.Content);
        entity.Id = request.Id;
        entity.Trips = new();
        try
        {
            await _unitOfWork.Cars.Save(entity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update not working...");
            return new(CustomStatusCode.ServerError);
        }
        return new(_mapper.Map<CarViewModel>(entity));
    }
}
