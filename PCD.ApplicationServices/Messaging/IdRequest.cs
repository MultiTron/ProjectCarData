namespace PCD.ApplicationServices.Messaging;
public class IdRequest : BaseRequest
{
    public int Id { get; set; }

    public IdRequest(int id)
    {
        Id = id;
    }

    public IdRequest()
    {

    }
}
