using Microsoft.EntityFrameworkCore;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;

public class UsersRepository : Repository<User, Guid>, IUsersRepository
{
    public UsersRepository(DbContext context) : base(context)
    {
    }
    public async override Task<IEnumerable<User>> GetAll()
        => await base.GetAll().Result.AsQueryable().Include("Cars").ToListAsync();
}
