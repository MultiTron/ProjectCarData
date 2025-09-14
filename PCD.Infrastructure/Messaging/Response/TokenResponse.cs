using PCD.Infrastructure.DTOs.Users;

namespace PCD.Infrastructure.Messaging.Response;
public class TokenResponse : BaseResponse
{
    public string? Token { get; set; }
    public UserViewModel? User { get; set; }
    public TokenResponse(CustomStatusCode status = CustomStatusCode.Success) : base(status)
    {

    }
    public TokenResponse(string? content = null, UserViewModel? user = null)
    {
        Token = content;
        User = user;
    }
}
