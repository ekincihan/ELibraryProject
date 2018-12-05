using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELibrary.Core.Entites
{
    public class EntityBase<Type> : IEntity
    {
        [Key]
        public Type Id { get; set; }
        public virtual Guid? CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual Guid? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
