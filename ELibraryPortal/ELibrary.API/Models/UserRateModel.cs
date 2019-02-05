using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ELibrary.API.Models
{
    public class UserRateModel
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public Guid UserId{ get; set; }
        public Guid BookId{ get; set; }
        public int Rate{ get; set; }
    }
}
