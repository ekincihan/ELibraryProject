using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELibrary.Entities.Concrete
{
    public class BookTagAssignment : EntityBase<Guid>
    {
        [ForeignKey("TagId")]
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
        [ForeignKey("BookId")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
