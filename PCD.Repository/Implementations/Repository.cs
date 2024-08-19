using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected DbSet<T> DbSet { get; set; }
    protected DbContext Context { get; private set; }
    public Repository(DbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context),
            "An instance of DbContext is required to use this repo.");
        DbSet = context.Set<T>();
    }
    public void Delete(T entity)
    {
        var entry = Context.Entry(entity);
        if (entry.State != EntityState.Deleted)
        {
            entry.State = EntityState.Deleted;
        }
        else
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }
    }

    public void Delete(int id)
    {
        var entity = DbSet.Find(id);
        if (entity != null)
        {
            Delete(entity);
        }
    }

    public async virtual Task<IEnumerable<T>> GetAll()
    {
        return await Task.Run(DbSet.AsQueryable);
    }

    public async Task<T> GetById(int id)
    {
        return await DbSet.FindAsync(id) ?? throw new Exception("Entry Not Found .i.");
    }

    public async Task<T> Insert(T entity)
    {
        entity.CreatedOn = DateTime.UtcNow;
        EntityEntry<T> entry = this.Context.Entry(entity);
        if (entry.State != EntityState.Detached)
        {
            entry.State = EntityState.Added;
        }
        else
        {
            await DbSet.AddAsync(entity);
        }
        return entity;
    }

    public async Task<T> Update(T entity, string excludeProperties = "")
    {
        entity.UpdatedOn = DateTime.UtcNow;
        EntityEntry<T> entry = Context.Entry(entity);
        if (entry.State != EntityState.Detached)
        {
            DbSet.Attach(entity);
        }
        entry.State = EntityState.Modified;
        entry.Property("CreatedOn").IsModified = false;
        foreach (var property in excludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            entry.Property(property).IsModified = false;
        }
        await Task.WhenAll();
        return entity;
    }
    public virtual async Task<T> Save(T entity)
    {
        if (entity.Id == 0)
        {
            return await Insert(entity);
        }
        else
        {
            return await Update(entity);
        }
        //}
        //protected static IQueryable<T> SoftDeleteQueryFilter(IQueryable<T> query, bool? isActive)
        //{
        //    if (isActive.HasValue)
        //    {
        //        query = query.Where(x => x.IsActive == isActive.Value);
        //    }
        //    return query;
        //}
    }

}
