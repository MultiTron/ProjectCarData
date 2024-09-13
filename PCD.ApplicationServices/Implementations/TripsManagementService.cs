using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Trips;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Request;
using PCD.Infrastructure.Messaging.Response;
using PCD.Repository.Interfaces;

namespace PCD.ApplicationServices.Implementations;
public class TripsManagementService : BaseManagementService, ITripsManagementService
{
    public TripsManagementService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CarsManagementService> logger) : base(mapper, unitOfWork, logger)
    {
    }
    public async Task<CreateResponse<TripViewModel>> CreateTrip(CreateRequest<TripAlterModel> request)
    {
        var responseTrip = await _unitOfWork.Trips.Save(_mapper.Map<Trip>(request.Content));
        var status = await _unitOfWork.SaveChangesAsync();
        if (status > 0)
        {
            return new(_mapper.Map<TripViewModel>(responseTrip));
        }
        else
        {
            return new() { StatusCode = CustomStatusCode.ClientError };
        }
    }

    public async Task<BaseResponse> DeleteTrip(IdRequest request)
    {
        try
        {
            await Task.Run(() => { _unitOfWork.Trips.Delete(request.Id); });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete Error...");
            return new(CustomStatusCode.ServerError);
        }
        return new();
    }

    public async Task<ListResponse<TripViewModel>> GetAllTrips()
        => new((await _unitOfWork.Trips.GetAll()).Select(_mapper.Map<TripViewModel>).ToList());

    public async Task<GetResponse<TripViewModel>> GetTripById(IdRequest request)
        => new(_mapper.Map<TripViewModel>(await _unitOfWork.Trips.GetById(request.Id)));

    public async Task<UpdateResponse<TripViewModel>> UpdateTrip(UpdateRequest<TripAlterModel> request)
    {
        var entity = _mapper.Map<Trip>(request.Content);
        entity.Id = request.Id;
        try
        {
            await _unitOfWork.Trips.Save(entity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update not working...");
            return new(CustomStatusCode.ServerError);
        }
        return new(_mapper.Map<TripViewModel>(entity));
    }
}
