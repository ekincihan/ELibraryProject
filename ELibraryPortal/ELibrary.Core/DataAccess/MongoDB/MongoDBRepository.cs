using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Core.Entites;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ELibrary.Core.DataAccess.MongoDB
{
    public class MongoDBRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<TEntity> _collection;
       
        public MongoDBRepository()
        {
            string connectionString =
                @"mongodb://baltazzar:4oFLThB7JxDNFN9ovCBkaMMaMCBFEdBaym9rGUlRLDFHcSOBtT7A1RhMbkcMJ1lHkzvSl8VCXVwXuqWPVYVwCw==@baltazzar.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(connectionString)
            );
            settings.SslSettings =
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            database = mongoClient.GetDatabase("ELibrary");
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public TEntity GetT(Expression<Func<TEntity, bool>> filter = null)  
        {
            return null;
        }

        public Task<TEntity> GetTAsync(Expression<Func<TEntity, bool>> filter = null)
        {

            throw new NotImplementedException();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> list = _collection.Find<TEntity>(filter).ToList();
            return list;
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
             _collection.InsertOne(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
