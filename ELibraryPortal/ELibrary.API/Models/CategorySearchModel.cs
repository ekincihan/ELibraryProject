using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class CategorySearchModel
    {
        public List<Guid> AuthorIds { get; set; }
        public List<Guid> CategoryIds { get; set; }
        public Guid PublisherId { get; set; }
    }
}
