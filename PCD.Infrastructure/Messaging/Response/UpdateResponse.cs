using PCD.Infrastructure.DTOs;

namespace PCD.Infrastructure.Messaging.Response;
public class UpdateResponse<T> : BaseResponse where T : BaseViewModel
{
    public T? Content { get; set; }
    public UpdateResponse(CustomStatusCode status = CustomStatusCode.Success) : base(status) { }
    public UpdateResponse(T content)
    {
        Content = content;
    }
}
