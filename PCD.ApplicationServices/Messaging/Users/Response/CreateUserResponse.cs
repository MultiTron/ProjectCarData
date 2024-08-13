using PCD.Infrastructure.DTOs.Users;

namespace PCD.ApplicationServices.Messaging.Users.Response;

public class CreateUserResponse : BaseResponse
{
    public UserViewModel? User { get; set; }

    public CreateUserResponse(UserViewModel user)
    {
        User = user;
    }
    public CreateUserResponse()
    {

    }
}
