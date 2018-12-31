using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;
using MongoDB.Bson;

namespace ELibrary.Entities.Concrete
{
    public class CategoryTagAssigment : MongoEntityBase<ObjectId>
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> Tags { get; set; }
    }
}
