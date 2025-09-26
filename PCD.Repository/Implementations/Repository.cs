using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PCD.Data.Entities;
using PCD.Repository.Interfaces;

namespace PCD.Repository.Implementations;
/// <summary>
/// Base Repository class
/// </summary>
/// <typeparam name="T">The T object must inherit BaseEntity</typeparam>
public class Repository<T, ID> : IRepository<T, ID> where T : BaseEntity
{
    /// <summary>
    /// Property for the DbSet of the T object
    /// </summary>
    protected DbSet<T> DbSet { get; set; }
    /// <summary>
    /// Generic DbContext instance
    /// </summary>
    protected DbContext Context { get; private set; }
    /// <summary>
    /// Repository constructor
    /// </summary>
    /// <param name="context">DbContext instance</param>
    /// <exception cref="ArgumentNullException">DbContext is null</exception>
    public Repository(DbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context),
            "An instance of DbContext is required to use this repo.");
        DbSet = context.Set<T>();
    }
    /// <summary>
    /// Deletes an entry from the database.
    /// </summary>
    /// <param name="entity">The entity object to be deleted from the database.</param>
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
    /// <summary>
    /// Deletes an entry from the database.
    /// </summary>
    /// <param name="id">The id of the entity to be deleted from the database.</param>
    public void Delete(ID id)
    {
        var entity = DbSet.Find(id);
        if (entity != null)
        {
            Delete(entity);
        }
    }
    /// <summary>
    /// Gets all entries from the DbSet
    /// </summary>
    /// <returns>A task that represents the asynchronos get operation. The task result contains an enumerable containing all entities from the DbSet.</returns>
    public async virtual Task<IEnumerable<T>> GetAll()
    {
        return await Task.Run(DbSet.AsQueryable);
    }
    /// <summary>
    /// Get entry from the DbSet by it's Id
    /// </summary>
    /// <param name="id">The id of the entity</param>
    /// <returns>A task that represents the asynchronos get operation. The task result contains an entity from the DbSet.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<T> GetById(ID id)
    {
        return await DbSet.FindAsync(id) ?? throw new Exception("Entry Not Found .i.");
    }
    /// <summary>
    /// Creates an EntityEntry and inserts it into the database.
    /// </summary>
    /// <param name="entity">The entity to be inserted</param>
    /// <returns>A task that represents the asynchronos insert operation. The task result contains the inserted entity.</returns>
    public async Task<T> Insert(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
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
    /// <summary>
    /// Updates the database entry via the parameter entity.
    /// </summary>
    /// <param name="entity">Object that represents the entity changes</param>
    /// <param name="excludeProperties">(Optional) String which excludes properties from being updated</param>
    /// <returns>A task that represents the asynchronos update operation. The task result contains the updated entity.</returns>
    public async Task<T> Update(T entity, string excludeProperties = "")
    {
        entity.UpdatedAt = DateTime.UtcNow;
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
    /// <summary>
    /// Determins, wheter the entity is present in the database. If True Updates the entity. Else Inserts the entity.
    /// </summary>
    /// <param name="entity">The entity to be inserted</param>
    /// <returns>A task that represents the asynchronos post operation. The task result contains the saved entity.</returns>
    public virtual async Task<T> Save(T entity)
    {
        if (entity.UpdatedAt == null)
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
