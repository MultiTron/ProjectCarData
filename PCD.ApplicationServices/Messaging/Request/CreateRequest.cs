using PCD.Data.Entities;

namespace PCD.ApplicationServices.Messaging.Request;

public class CreateRequest<T> : BaseRequest where T : BaseEntity
{
    public CreateRequest(T content)
    {
        Content = content;
    }
    public T Content { get; set; }
}
