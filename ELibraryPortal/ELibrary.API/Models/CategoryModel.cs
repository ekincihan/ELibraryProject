using ELibrary.API.Base;
using ELibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.DAL.Abstract;
using ELibrary.DAL.Concrete.EntityFramework;

namespace ELibrary.API.Models
{
    public class CategoryModel:ModelBase<Guid>,IModelBase
    {
        public CategoryModel()
        {
            Id = Guid.Empty;
            Books= new List<MongoBookModel>();
        }
        public string Name { get; set; }
        public Guid AppTypeId { get; set; }
        public bool IsActive { get; set; } = true;
        public BookModel Book { get; set; }
        public List<MongoBookModel> Books { get; set; }

    }
}
