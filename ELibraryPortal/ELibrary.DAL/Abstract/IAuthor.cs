using ELibrary.Core.DataAccess;
using ELibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.DAL.Abstract
{
    public interface IAuthor : IEntityRepository<Author>
    {
    }
}
