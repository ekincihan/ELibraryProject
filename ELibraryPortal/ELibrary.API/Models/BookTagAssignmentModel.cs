using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class BookTagAssignmentModel : ModelBase<Guid>, IModelBase
    {
        public BookTagAssignmentModel()
        {
            Id = Guid.Empty;
        }
        public Guid TagId { get; set; }
        public TagModel Tag { get; set; }
        public Guid BookId { get; set; }
        public BookModel Book { get; set; }
    }
}
