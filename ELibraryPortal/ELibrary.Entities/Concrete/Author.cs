using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELibrary.Entities.Concrete
{
    public class Author : EntityBase<Guid>
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string Surname{ get; set; }
        [StringLength(maximumLength: 10000)]
        public string Biography { get; set; }
        public int Gender{ get; set; }
        public Base64FormattingOptions AuthorPhoto { get; set; }
        public ICollection<Book> Books { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Birthdate { get; set; }
        public override Guid? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        public override DateTime? CreatedDate { get => DateTime.UtcNow; set => base.CreatedDate = value; }
        public override Guid? ModifiedBy { get => base.ModifiedBy; set => base.ModifiedBy = value; }
        public override DateTime? ModifiedDate { get => DateTime.UtcNow; set => base.ModifiedDate = value; }
    }
}
