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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>().ToTable("cars");
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Trip>().ToTable("trips");

        modelBuilder.Entity<BaseEntity>().ToTable("base");

        modelBuilder.Entity<BaseEntity>()
            .Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()");
        modelBuilder.Entity<BaseEntity>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()");
    }
}
