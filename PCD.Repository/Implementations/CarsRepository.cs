using Microsoft.EntityFrameworkCore;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;

public class CarsRepository : Repository<Car, Guid>, ICarsRepository
{
    public CarsRepository(DbContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<Car>> GetAll()
        => await base.GetAll().Result.AsQueryable().Include("Trips").ToListAsync();
    public override async Task<Car> Save(Car entity)
    {
        entity.User = Context.Find<User>(entity.Id);
        return await base.Save(entity);
    }
    public async Task<List<Car>> GetCarsByUser(Guid userId)
    {
        return (await base.GetAll()).Where(x => x.UserId == userId).ToList();
    }
}
