using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFContact: EfEntityRepositoryBase<Contact, ELibraryDBContext>, IContact
    {
    }
}
