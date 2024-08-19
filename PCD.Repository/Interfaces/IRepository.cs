using PCD.Data.Entities;

namespace PCD.Repository.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Save(T entity);
    Task<T> Insert(T entity);
    Task<T> Update(T entity, string excludeProperties = "");
    void Delete(T entity);
    void Delete(int id);
}
