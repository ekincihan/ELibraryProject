﻿using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELibrary.Entities.Concrete
{
     public  class AppType:EntityBase<Guid>
    {
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public override Guid? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        public override DateTime? CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
        public override Guid? ModifiedBy { get => base.ModifiedBy; set => base.ModifiedBy = value; }
        public override DateTime? ModifiedDate { get => base.ModifiedDate; set => base.ModifiedDate = value; }
    }
}
