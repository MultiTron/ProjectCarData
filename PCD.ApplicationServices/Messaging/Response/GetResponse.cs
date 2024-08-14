using PCD.Data.Entities;

namespace PCD.ApplicationServices.Messaging.Response;

public class GetResponse<T> : BaseResponse where T : BaseEntity
{
    public T? Content { get; set; }
    public GetResponse(T? content = null)
    {
        Content = content;
    }
}
