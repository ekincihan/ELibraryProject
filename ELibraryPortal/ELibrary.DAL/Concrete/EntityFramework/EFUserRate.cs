using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFUserRate : EfEntityRepositoryBase<UserRates, ELibraryDBContext>, IUserRates
    {
    }
}
