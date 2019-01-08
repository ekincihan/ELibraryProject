using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.DataAccess.MongoDB;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using MongoDB.Bson;

namespace ELibrary.DAL.Concrete.MongoDB
{
    public class MongoCategoryTagAssigments:MongoDBRepository<CategoryTagAssigment>, IMongoTagCategoryAssigment
    {
    }
}
