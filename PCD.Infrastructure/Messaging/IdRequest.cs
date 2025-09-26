namespace PCD.Infrastructure.Messaging;
public class IdRequest : BaseRequest
{
    public Guid Id { get; set; }

    public IdRequest(Guid id)
    {
        Id = id;
    }

    public IdRequest()
    {

    }
}
