using Microsoft.EntityFrameworkCore;

namespace PCD.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    DbContext Context { get; }
    ICarsRepository Cars { get; }
    Task<int> SaveChangesAsync();
}
