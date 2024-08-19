using PCD.ApplicationServices.Messaging;
using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Infrastructure.DTOs.Trips;

namespace PCD.ApplicationServices.Interfaces;
public interface ITripsManagementService
{
    public Task<ListResponse<TripViewModel>> GetAllTrips();
    public Task<GetResponse<TripViewModel>> GetTripById(IdRequest request);
    public Task<CreateResponse<TripViewModel>> CreateTrip(CreateRequest<TripAlterModel> request);
    public Task<UpdateResponse<TripViewModel>> UpdateTrip(UpdateRequest<TripAlterModel> request);
    public Task<BaseResponse> DeleteTrip(IdRequest request);
}
