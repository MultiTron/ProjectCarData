using PCD.Infrastructure.DTOs.Users;

namespace PCD.ApplicationServices.Messaging.Users.Response;

public class GetUsersResponse : BaseResponse
{
    public List<UserViewModel> Users { get; set; }
    public GetUsersResponse()
    {
        Users = new List<UserViewModel>();
    }
    public GetUsersResponse(List<UserViewModel> users)
    {
        Users = users;
    }
}
