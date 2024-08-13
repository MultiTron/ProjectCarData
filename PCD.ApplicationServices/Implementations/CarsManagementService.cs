﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging.Cars.Request;
using PCD.ApplicationServices.Messaging.Cars.Response;
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

    public async Task<CreateCarResponse> CreateCar(CreateCarRequest request)
    {
        var responseCar = await _unitOfWork.Cars.Insert(_mapper.Map<Car>(request.Car));
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

    public async Task<GetCarsResponse> GetAllCarsAsync()
        => new((await _unitOfWork.Cars.GetAll()).Select(_mapper.Map<CarViewModel>).ToList());

    public async Task<GetCarResponse> GetCarById(int id)
        => new(_mapper.Map<CarViewModel>(await _unitOfWork.Cars.GetById(id)));
}
