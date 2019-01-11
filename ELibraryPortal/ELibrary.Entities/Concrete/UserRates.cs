using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ELibrary.Entities.Concrete
{
    public class UserRates : MongoEntityBase<ObjectId>
    {
        [BsonElement("UserId")]
        public Guid UserId { get; set; }
        [BsonElement("BookId")]
        public Guid BookId { get; set; }
        [BsonElement("Rate")]
        public int Rate { get; set; }
    }
}
