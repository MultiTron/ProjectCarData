using PCD.ApplicationServices.Messaging;
using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Infrastructure.DTOs.Cars;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.ApplicationServices.Interfaces;

public interface IUsersManagementService
{
    public Task<ListResponse<UserViewModel>> GetAllUsers();
    public Task<GetResponse<UserViewModel>> GetUserById(IdRequest request);
    public Task<ListResponse<CarViewModel>> GetCarsByUser(IdRequest request);
    public Task<CreateResponse<UserViewModel>> CreateUser(CreateRequest<UserAlterModel> request);
    public Task<UpdateResponse<UserViewModel>> UpdateUser(UpdateRequest<UserAlterModel> request);
    public Task<BaseResponse> DeleteUser(IdRequest request);
    public Task<TokenResponse> Authenticate(string clientId, string secret);
}
