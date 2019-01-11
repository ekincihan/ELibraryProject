using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ELibrary.Core.Entites
{
    public class MongoEntityBase<ObjectId> : BsonDocument,IEntity
    {  
        [BsonId]
        public ObjectId _id { get; set; }
        public virtual Guid? CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual Guid? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
