using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELibrary.Entities.Concrete
{
    public class CategoryTagAssignment : EntityBase<Guid>
    {
        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
