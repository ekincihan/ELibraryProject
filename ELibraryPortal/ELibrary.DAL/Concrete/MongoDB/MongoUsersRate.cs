using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.DataAccess.MongoDB;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Concrete.MongoDB
{
    public class MongoUsersRate : MongoDBRepository<UserRates>, IMongoUserRates
    {

    }
}
