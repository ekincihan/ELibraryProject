using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Core.DataAccess.MongoDB;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.DAL.Concrete.MongoDB
{
    public class MongoUserFavoritesAndReads : MongoDBRepository<UsersFavoritesAndReads>, IMongoUserFavoritesAndReads
    {
       
    }
}
