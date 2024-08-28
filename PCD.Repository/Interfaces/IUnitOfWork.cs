using Microsoft.EntityFrameworkCore;

namespace PCD.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Generic DbContext property
    /// </summary>
    DbContext Context { get; }
    /// <summary>
    /// Cars Repository
    /// </summary>
    ICarsRepository Cars { get; }
    /// <summary>
    /// Trips Repository
    /// </summary>
    ITripsRepository Trips { get; }
    /// <summary>
    /// Users Repository
    /// </summary>
    IUsersRepository Users { get; }
    /// <summary>
    /// Detects and Saves the current changes to the database context.
    /// </summary>
    /// <returns>A task that represents the asynchronos save operation. The task result contains the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync();
}
