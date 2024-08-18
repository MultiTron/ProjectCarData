using PCD.Infrastructure.DTOs;

namespace PCD.ApplicationServices.Messaging.Response;

public class CreateResponse<T> : BaseResponse where T : BaseViewModel
{
    public T? Content { get; set; }
    public CreateResponse(StatusCode status = StatusCode.Success) : base(status) { }
    public CreateResponse(T content)
    {
        Content = content;
    }
}
