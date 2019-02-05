using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ELibrary.Entities.Concrete
{
    public class UserRates : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public int Rate { get; set; }
    }
}
