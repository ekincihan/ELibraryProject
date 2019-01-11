using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Core.Entites;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.Core.DataAccess.MongoDB
{
    public class MongoDBRepository<TEntity> : IMongoEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<TEntity> _collection;
        private readonly IMongoCollection<BsonDocument> _collectionbson;

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
            _collectionbson = database.GetCollection<BsonDocument>(typeof(TEntity).Name);
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
            List<TEntity> list = filter == null ? _collection.AsQueryable().ToList() : _collection.Find<TEntity>(filter).ToList();

            return list;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? await _collection.Find(_ => true).ToListAsync() : await _collection.Find<TEntity>(filter).ToListAsync();
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

        public bool Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            var result = _collection.UpdateOne(filter, updateDefinition);

            return result.IsModifiedCountAvailable;
        }

        public async Task<bool> UpdateAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            var result = await _collection.UpdateOneAsync(filter, updateDefinition);

            return result.IsModifiedCountAvailable;
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
