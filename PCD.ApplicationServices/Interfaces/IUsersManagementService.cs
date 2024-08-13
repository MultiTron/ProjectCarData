using PCD.ApplicationServices.Messaging.Users.Request;
using PCD.ApplicationServices.Messaging.Users.Response;

namespace PCD.ApplicationServices.Interfaces;

public interface IUsersManagementService
{
    public Task<GetUsersResponse> GetAllUsers();
    public Task<CreateUserResponse> CreateUser(CreateUserRequest request);
}
