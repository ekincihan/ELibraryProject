using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using Type = ELibrary.Entities.Concrete.Type;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFType : EfEntityRepositoryBase<Type, ELibraryDBContext>, IType
    {

    }
}
