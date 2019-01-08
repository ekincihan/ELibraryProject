using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;
using MongoDB.Bson;

namespace ELibrary.Entities.Concrete
{
    public class UserRates : MongoEntityBase<ObjectId>
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public int Rate { get; set; }
    }
}
