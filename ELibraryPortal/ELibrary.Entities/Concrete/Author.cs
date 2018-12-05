using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Gender{ get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Birthdate { get; set; }
        public Guid? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        public DateTime? CreatedDate { get => DateTime.UtcNow; set => base.CreatedDate = value; }
        public Guid? ModifiedBy { get => base.ModifiedBy; set => base.ModifiedBy = value; }
        public DateTime? ModifiedDate { get => DateTime.UtcNow; set => base.ModifiedDate = value; }
    }
}
