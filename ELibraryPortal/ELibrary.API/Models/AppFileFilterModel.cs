using ELibrary.API.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ELibrary.API.Models.Enum.Enum;

namespace ELibrary.API.Models
{
    public class AppFileFilterModel :ModelBase<Guid>
    {
        public IFormFile File { get; set; }
        public Guid AppFileModuleId { get; set; }
        public Module ModuleType { get; set; }
    }
}
