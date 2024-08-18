﻿using Microsoft.EntityFrameworkCore;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;

public class CarsRepository : Repository<Car>, ICarsRepository
{
    public CarsRepository(DbContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<Car>> GetAll()
        => await base.GetAll().Result.AsQueryable().Include("Trips").ToListAsync();
    public async Task<List<Car>> GetCarsByUser(int userId)
    {
        return (await base.GetAll()).Where(x => x.UserId == userId).ToList();
    }
}
