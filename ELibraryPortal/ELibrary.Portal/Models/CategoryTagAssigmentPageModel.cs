using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;

namespace ELibrary.Portal.Models
{
    public class CategoryTagAssigmentPageModel
    {
        public List<CategoryModel> CategoryList { get; set; }
        public List<BookModel> BooklList { get; set; }
        public List<TagModel> TagList { get; set; }

    }
}
