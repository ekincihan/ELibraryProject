using ELibrary.API.Base;
using ELibrary.API.Manager;
using ELibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ELibrary.API.Models.Enum.Enum;

namespace ELibrary.API.Models
{
    public class AppFileModel: ModelBase<Guid>, IModelBase
    {
        public string SignUrl
        {
            get
            {
                DateTime startDate = DateTime.Now.AddMinutes(-5);
                BlobManager<AppFile> manager = new BlobManager<AppFile>();
                if (BlobPath == null)
                    return "";
                var singUrl = manager.SignUrl(this.UniqueName.ToLower(), this.BlobPath.ToLower(), startDate, startDate.AddMinutes(10));
                return singUrl;
            }
        }
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public string Extension { get; set; }
        public string BlobPath { get; set; }
        public Guid ModuleId { get; set; }
        public Module ModuleType { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
    }
}
