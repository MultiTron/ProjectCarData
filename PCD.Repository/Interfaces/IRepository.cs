using PCD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCD.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Save(T entity);
        void Insert(T entity);
        void Update(T entity, string excludeProperties = "");
        void Delete(T entity);
        void Delete(int id);
    }
}
