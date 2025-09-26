using PCD.Infrastructure.DTOs;

namespace PCD.Infrastructure.Messaging.Request
{
    public class UpdateRequest<T> : IdRequest where T : BaseAlterModel
    {
        public T Content { get; set; }
        public UpdateRequest(Guid id, T content) : base(id)
        {
            Content = content;
        }
    }
}
