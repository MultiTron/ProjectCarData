﻿using PCD.Data.Entities;

namespace PCD.Repository.Interfaces;

public interface ICarsRepository : IRepository<Car>
{
    public Task<List<Car>> GetCarsByUser(int userId);
}
