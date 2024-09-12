using PCD.Infrastructure.DTOs.Trips;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Request;
using PCD.Infrastructure.Messaging.Response;

namespace PCD.ApplicationServices.Interfaces;
public interface ITripsManagementService
{
    public Task<ListResponse<TripViewModel>> GetAllTrips();
    public Task<GetResponse<TripViewModel>> GetTripById(IdRequest request);
    public Task<CreateResponse<TripViewModel>> CreateTrip(CreateRequest<TripAlterModel> request);
    public Task<UpdateResponse<TripViewModel>> UpdateTrip(UpdateRequest<TripAlterModel> request);
    public Task<BaseResponse> DeleteTrip(IdRequest request);
}
