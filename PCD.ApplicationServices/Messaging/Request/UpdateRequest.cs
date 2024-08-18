using PCD.Infrastructure.DTOs;

namespace PCD.ApplicationServices.Messaging.Request
{
    public class UpdateRequest<T> : IdRequest where T : BaseAlterModel
    {
        public T Content { get; set; }
        public UpdateRequest(int id, T content) : base(id)
        {
            Content = content;
        }
    }
}
