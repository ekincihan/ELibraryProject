using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFType : EfEntityRepositoryBase<AppType, ELibraryDBContext>, IType
    {

    }
}
