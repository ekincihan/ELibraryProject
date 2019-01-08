using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;

namespace ELibrary.Core.Entites
{
    public class MongoEntityBase<ObjectId> : IEntity
    {  
        [Key]
        public ObjectId Id { get; set; }
        public virtual Guid? CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual Guid? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
