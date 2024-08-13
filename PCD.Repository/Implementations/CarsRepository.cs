using Microsoft.EntityFrameworkCore;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;

public class CarsRepository : Repository<Car>, ICarsRepository
{
    public CarsRepository(DbContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<Car>> GetAll()
        => await base.GetAll().Result.AsQueryable().Include("Trip").ToListAsync();
}
