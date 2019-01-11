using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using ELibrary.Core.DataAccess.MongoDB;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.DAL.Concrete.MongoDB
{
    public class MongoCategoryTagAssigments:MongoDBRepository<CategoryTagAssigment>, IMongoTagCategoryAssigment
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<CategoryTagAssigment> _collection;

        public MongoCategoryTagAssigments()
        {
            string connectionString =
                @"mongodb://baltazzar:4oFLThB7JxDNFN9ovCBkaMMaMCBFEdBaym9rGUlRLDFHcSOBtT7A1RhMbkcMJ1lHkzvSl8VCXVwXuqWPVYVwCw==@baltazzar.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(connectionString)
            );
            settings.SslSettings =
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase("ELibrary");
            _collection = _database.GetCollection<CategoryTagAssigment>(typeof(CategoryTagAssigment).Name);
        }

        public List<CategoryTagAssigment> Search(string value)
        {
              var results = _collection.Find(x => x.AuthorName.ToLower().Contains(value.ToLower()) || 
                                                  x.AuthorSurname.ToLower().Contains(value.ToLower()) ||
                                                  x.BookName.ToLower().Contains(value.ToLower()) ||
                                                  x.PublisherName.ToLower().Contains(value.ToLower())).ToList();

            return results;

        }
    }
}
