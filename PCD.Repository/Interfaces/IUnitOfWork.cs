using Microsoft.EntityFrameworkCore;

namespace PCD.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    DbContext Context { get; }
    ICarsRepository Cars { get; }
    ITripsRepository Trips { get; }
    IUsersRepository Users { get; }
    Task<int> SaveChangesAsync();
}
