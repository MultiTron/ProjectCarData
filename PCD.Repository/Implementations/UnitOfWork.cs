using Microsoft.EntityFrameworkCore;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly DbContext _context;

        public DbContext Context => _context;
        //TODO: add repositories
        public UnitOfWork(DbContext context)
        {
            _context = context;
            //TODO: initialize repositories with context
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
