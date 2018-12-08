using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFPublisher : EfEntityRepositoryBase<Publisher, ELibraryDBContext>, IPublisher
    {

    }
}
