using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFTag : EfEntityRepositoryBase<Tag, ELibraryDBContext>, ITag
    {

    }
}
