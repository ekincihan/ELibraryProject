using ELibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Models
{
    public class CategoryPageModel
    {
        public List<CategoryModel> CategoryList { get; set; }

        public List<TypeModel> TypeList { get; set; }

        public CategoryModel catogoryModel { get; set; }

    }
}
