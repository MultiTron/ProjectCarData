using PCD.Infrastructure.DTOs;

namespace PCD.Infrastructure.Messaging.Response;

public class ListResponse<T> : BaseResponse where T : BaseViewModel
{
    public List<T> Content { get; set; }

    public ListResponse(List<T> content)
    {
        Content = content;
    }
    public ListResponse(CustomStatusCode status = CustomStatusCode.Success) : base(status)
    {
        Content = new List<T>();
    }
}
