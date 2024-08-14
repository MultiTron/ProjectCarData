using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.ApplicationServices.Interfaces;

public interface IUsersManagementService
{
    public Task<GetResponse<UserViewModel>> GetAllUsers();
    public Task<CreateResponse<UserViewModel>> CreateUser(CreateRequest<UserAlterModel> request);
}
