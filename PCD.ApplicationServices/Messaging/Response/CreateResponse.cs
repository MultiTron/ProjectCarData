using PCD.Data.Entities;

namespace PCD.ApplicationServices.Messaging.Response;

public class CreateResponse<T> : BaseResponse where T : BaseEntity
{
    public T? Content { get; set; }
    public CreateResponse() { }
    public CreateResponse(T content)
    {
        Content = content;
    }
}
