using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELibrary.Entities.Concrete
{
    public class AppFile : EntityBase<Guid>
    {
        public string Name { get; set; }
        [NotMapped]
        public string FilePath { get; set; }
        public string SignUrl { get; set; }
        public string UniqueName { get; set; }
        public string Extension { get; set; }
        public string BlobPath { get; set; }
        public Guid ModuleId { get; set; }
        public int ModuleType { get; set; }
        public override Guid? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        public override Guid? ModifiedBy { get => base.ModifiedBy; set => base.ModifiedBy = value; }
        public override DateTime? CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
        public override DateTime? ModifiedDate { get => base.ModifiedDate; set => base.ModifiedDate = value; }
    }
}
