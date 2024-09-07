using PCD.Data.Entities;

namespace PCD.Repository.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Gets all entries from the DbSet
    /// </summary>
    /// <returns>A task that represents the asynchronos get operation. The task result contains an enumerable containing all entities from the DbSet.</returns>
    Task<IEnumerable<T>> GetAll();
    /// <summary>
    /// Get entry from the DbSet by it's Id
    /// </summary>
    /// <param name="id">The id of the entity</param>
    /// <returns>A task that represents the asynchronos get operation. The task result contains an entity from the DbSet.</returns>
    /// <exception cref="Exception"></exception>
    Task<T> GetById(int id);
    /// <summary>
    /// Determins, wheter the entity is present in the database. If True Updates the entity. Else Inserts the entity.
    /// </summary>
    /// <param name="entity">The entity to be inserted</param>
    /// <returns>A task that represents the asynchronos post operation. The task result contains the saved entity.</returns>
    Task<T> Save(T entity);
    /// <summary>
    /// Creates an EntityEntry and inserts it into the database.
    /// </summary>
    /// <param name="entity">The entity to be inserted</param>
    /// <returns>A task that represents the asynchronos insert operation. The task result contains the inserted entity.</returns>
    Task<T> Insert(T entity);
    /// <summary>
    /// Updates the database entry via the parameter entity.
    /// </summary>
    /// <param name="entity">Object that represents the entity changes</param>
    /// <param name="excludeProperties">(Optional) String which excludes properties from being updated</param>
    /// <returns>A task that represents the asynchronos update operation. The task result contains the updated entity.</returns>
    Task<T> Update(T entity, string excludeProperties = "");
    /// <summary>
    /// Deletes an entry from the database.
    /// </summary>
    /// <param name="entity">The entity object to be deleted from the database.</param>
    void Delete(T entity);
    /// <summary>
    /// Deletes an entry from the database.
    /// </summary>
    /// <param name="id">The id of the entity to be deleted from the database.</param>
    void Delete(int id);
}
