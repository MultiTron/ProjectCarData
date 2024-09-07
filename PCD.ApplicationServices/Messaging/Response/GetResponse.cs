using PCD.Infrastructure.DTOs;

namespace PCD.ApplicationServices.Messaging.Response;

public class GetResponse<T> : BaseResponse where T : BaseViewModel
{
    public T? Content { get; set; }
    public GetResponse(CustomStatusCode status = CustomStatusCode.Success) : base(status)
    {

    }
    public GetResponse(T? content = null)
    {
        Content = content;
    }
}
