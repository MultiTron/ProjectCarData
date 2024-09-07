namespace PCD.ApplicationServices.Messaging.Response;
public class TokenResponse : BaseResponse
{
    public string? Token { get; set; }
    public TokenResponse(CustomStatusCode status = CustomStatusCode.Success) : base(status)
    {

    }
    public TokenResponse(string? content = null)
    {
        Token = content;
    }
}
