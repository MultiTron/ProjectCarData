using Microsoft.EntityFrameworkCore;

namespace PCD.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    DbContext Context { get; }
    Task<int> SaveChangesAsync();
}
