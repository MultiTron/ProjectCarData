using PCD.Data.Entities;

namespace PCD.Repository.Interfaces;

public interface ICarsRepository : IRepository<Car, Guid>
{
    public Task<List<Car>> GetCarsByUser(Guid userId);
}
