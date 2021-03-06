﻿using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELibrary.Entities.Concrete
{
    public class Publisher : EntityBase<Guid>
    {
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        public override Guid? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        public override DateTime? CreatedDate { get => DateTime.UtcNow; set => base.CreatedDate = value; }
        public override Guid? ModifiedBy { get => base.ModifiedBy; set => base.ModifiedBy = value; }
        public override DateTime? ModifiedDate { get => DateTime.UtcNow; set => base.ModifiedDate = value; }
    }
}
