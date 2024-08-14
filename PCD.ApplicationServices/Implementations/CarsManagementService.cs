using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging;
using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Cars;
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
        var responseCar = await _unitOfWork.Cars.Insert(_mapper.Map<Car>(request.Content));
        var status = await _unitOfWork.SaveChangesAsync();
        if (status > 0)
        {
            return new(_mapper.Map<CarViewModel>(responseCar));
        }
        else
        {
            return new() { StatusCode = Messaging.StatusCode.ClientError };
        }
    }

    public async Task<ListResponse<CarViewModel>> GetAllCarsAsync()
        => new((await _unitOfWork.Cars.GetAll()).Select(_mapper.Map<CarViewModel>).ToList());

    public async Task<GetResponse<CarViewModel>> GetCarById(IdRequest request)
        => new(_mapper.Map<CarViewModel>(await _unitOfWork.Cars.GetById(request.Id)));
}
