using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ELibrary.API.Models.Enum.Enum;

namespace ELibrary.API.Models
{
    public class AppFileModel: ModelBase<Guid>, IModelBase
    {
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public string Extension { get; set; }
        public string BlobPath { get; set; }
        public Guid ModuleId { get; set; }
        public Module ModuleType { get; set; }
        public string FilePath { get; set; }
    }
}
