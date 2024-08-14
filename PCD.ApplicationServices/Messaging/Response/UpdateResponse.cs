using PCD.Infrastructure.DTOs;

namespace PCD.ApplicationServices.Messaging.Response;
public class UpdateResponse<T> : BaseResponse where T : BaseViewModel
{
    public T? Content { get; set; }
    public UpdateResponse() { }
    public UpdateResponse(T content)
    {
        Content = content;
    }
}
