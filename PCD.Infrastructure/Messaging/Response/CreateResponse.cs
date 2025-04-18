using PCD.Infrastructure.DTOs;

namespace PCD.Infrastructure.Messaging.Response;

public class CreateResponse<T> : BaseResponse where T : BaseViewModel
{
    public T? Content { get; set; }
    public CreateResponse(CustomStatusCode status = CustomStatusCode.Success) : base(status) { }
    public CreateResponse(T content)
    {
        Content = content;
    }
}
