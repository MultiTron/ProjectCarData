namespace PCD.ApplicationServices.Messaging;

public class BaseResponse
{
    public StatusCode StatusCode { get; set; }
    public BaseResponse()
    {
        StatusCode = StatusCode.Success;
    }
    public BaseResponse(StatusCode status)
    {
        StatusCode = status;
    }
}
