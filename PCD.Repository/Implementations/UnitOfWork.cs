using Microsoft.EntityFrameworkCore;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;
/// <summary>
/// The UnitOfWork Layer
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private bool disposedValue;
    /// <summary>
    /// Generic DbContext instance
    /// </summary>
    private readonly DbContext _context;
    /// <summary>
    /// Generic DbContext property
    /// </summary>
    public DbContext Context => _context;
    /// <summary>
    /// Cars Repository
    /// </summary>
    public ICarsRepository Cars { get; set; }
    /// <summary>
    /// Users Repository
    /// </summary>
    public IUsersRepository Users { get; set; }
    /// <summary>
    /// Trips Repository
    /// </summary>
    public ITripsRepository Trips { get; set; }
    /// <summary>
    /// UnitOfWork constructor
    /// </summary>
    /// <param name="context">DbContext instance</param>
    public UnitOfWork(DbContext context)
    {
        _context = context;
        Cars = new CarsRepository(context);
        Users = new UsersRepository(context);
        Trips = new TripsRepository(context);
    }
    /// <summary>
    /// Detects and Saves the current changes to the database context.
    /// </summary>
    /// <returns>A task that represents the asynchronos save operation. The task result contains the number of state entries written to the database.</returns>
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    /// <summary>
    /// Dispose method.
    /// </summary>
    /// <param name="disposing">If True disposes of managed state (managed objects).</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                _context.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~UnitOfWork()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }
    /// <summary>
    /// Disposes of the DbContext instance.
    /// </summary>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
