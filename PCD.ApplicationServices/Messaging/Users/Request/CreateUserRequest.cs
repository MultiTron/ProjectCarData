using PCD.Infrastructure.DTOs.Users;

namespace PCD.ApplicationServices.Messaging.Users.Request
{
    public class CreateUserRequest
    {
        public UserAlterModel User { get; set; }
        public CreateUserRequest(UserAlterModel user)
        {
            User = user;
        }
    }
}
