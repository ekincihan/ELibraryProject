using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ELibrary.API.Base;
using ELibrary.DAL.Abstract;
using ELibrary.DAL.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace ELibrary.API.Models
{
    public class BannerModel : ModelBase<Guid>,IModelBase
    {
        private readonly IAppFile _appFile;
        public BannerModel()
        {
            _appFile = new EFAppFile();
            Id = Guid.Empty;
        }
        public string Name { get; set; }
        public AppFileModel AppFileModel {
            get
            {
                return _appFile.GetList(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.Banner)).
                Select(f => new AppFileModel
                {
                    BlobPath = f.BlobPath,
                    FilePath = "",
                    Id = f.Id,
                    Extension = f.Extension,
                    ModuleId = f.ModuleId,
                    ModuleType = Enum.Enum.Module.Banner,
                    Name = f.Name,
                    SignUrl = f.SignUrl,
                    UniqueName = f.UniqueName
                }).FirstOrDefault();
            }
        }
        [IgnoreDataMember()]
        public IFormFile FormFile { get; set; }
        public bool IsActive { get; set; }
    }
}
