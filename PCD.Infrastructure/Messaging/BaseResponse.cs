namespace PCD.Infrastructure.Messaging;

public class BaseResponse
{
    public CustomStatusCode StatusCode { get; set; }
    public BaseResponse()
    {
        StatusCode = CustomStatusCode.Success;
    }
    public BaseResponse(CustomStatusCode status)
    {
        StatusCode = status;
    }
}
