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
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> Tags { get; set; }
    }
}
