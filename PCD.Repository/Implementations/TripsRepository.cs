using Microsoft.EntityFrameworkCore;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;
public class TripsRepository : Repository<Trip>, ITripsRepository
{
    public TripsRepository(DbContext context) : base(context)
    {
    }
}
