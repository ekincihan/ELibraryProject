using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Core.DataAccess;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Abstract
{
    public interface IMongoUserFavoritesAndReads : IMongoEntityRepository<UsersFavoritesAndReads>
    {
    }
}
