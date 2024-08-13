using Microsoft.EntityFrameworkCore;
using PCD.Data.Entities;

namespace PCD.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Trip> Trips { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}
