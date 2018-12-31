using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Base;
using MongoDB.Bson;

namespace ELibrary.API.Models
{
    public class CategoryTagAssigmentModel: IModelBase
    {
        public string id { get; set; }
        public MongoBookModel BookId { get; set; }
        public MongoCategoryModel CategoryId { get; set; }
        public List<Guid> Tags { get; set; }
    }


    public class MongoCategoryModel
    {
        public string Name{ get; set; }
        public Guid CategoryId { get; set; }
    }

    public class MongoBookModel
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }

    }
}
