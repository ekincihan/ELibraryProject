using ELibrary.Core.DataAccess.EntityFramework;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class EFCategoryTagAssigment: EfEntityRepositoryBase<CategoryTagAssigment, ELibraryDBContext>, ICategoryTagAssignment
    {
        public List<CategoryTagAssigment> Search(string value)
        {
            using (var context = new ELibraryDBContext())
            {
                var results = context.CategoryTagAssigments.Where(x => x.AuthorName.ToLower().Contains(value.ToLower()) ||
                                                             x.AuthorSurname.ToLower().Contains(value.ToLower()) ||
                                                             x.BookName.ToLower().Contains(value.ToLower()) ||
                                                             x.PublisherName.ToLower().Contains(value.ToLower())).ToList();

                return results;
            }
        }
    }
}
