using PCD.Infrastructure.DTOs;

namespace PCD.Infrastructure.Messaging.Request;

public class CreateRequest<T> : BaseRequest where T : BaseAlterModel
{
    public T Content { get; set; }
    public CreateRequest(T content)
    {
        Content = content;
    }
}
