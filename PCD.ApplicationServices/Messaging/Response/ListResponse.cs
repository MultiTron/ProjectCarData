using PCD.Data.Entities;

namespace PCD.ApplicationServices.Messaging.Response;

public class ListResponse<T> : BaseResponse where T : BaseEntity
{
    public List<T> Content { get; set; }

    public ListResponse(List<T> content)
    {
        Content = content;
    }
    public ListResponse()
    {
        Content = new List<T>();
    }
}
