using System.Collections.Generic;
using ELibrary.Core.DataAccess;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Abstract
{
    public interface ICategoryTagAssignment : IEntityRepository<CategoryTagAssigment>
    {
        List<CategoryTagAssigment> Search(string value);
    }
}
