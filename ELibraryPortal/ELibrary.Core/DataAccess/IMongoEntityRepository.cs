using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Core.Entites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.Core.DataAccess
{
    public interface IMongoEntityRepository<T> where T : class, IEntity, new()
    {
        T GetT(FilterDefinition<T> filter);
        Task<T> GetTAsync(FilterDefinition<T> filter);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        bool Update(FilterDefinition<T> filter, UpdateDefinition<T> updateDefinition);
        Task<bool> UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> updateDefinition);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
