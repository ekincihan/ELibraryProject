using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Configuration;
using ELibrary.DAL.Abstract;
using ELibrary.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace ELibrary.API.Models
{
    public class AuthorModel : ModelBase<Guid>, IModelBase
    {
        private readonly IAppFile _appFile;
        private IMapper _mapper;
        public AuthorModel()
        {
            _appFile = new EFAppFile();
            _mapper = DIManager.Instance.Provider.GetService<IMapper>();
        }
        [Required]
        public string Name { get; set; }
        public AppFileModel Thumbnail
        {
            get
            {
                return _appFile.GetList(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.AuthorThumbnail)).
                Select(f => new AppFileModel
                    {
                        BlobPath = f.BlobPath,
                        FilePath = f.FilePath,
                        Id = f.Id,
                        Extension = f.Extension,
                        ModuleId = f.ModuleId,
                        ModuleType = Enum.Enum.Module.AuthorThumbnail,
                        Name = f.Name,
                        UniqueName = f.UniqueName
                    }).FirstOrDefault();

            }
        }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public int Gender { get; set; }
        public Base64FormattingOptions AuthorPhoto { get; set; }
        [IgnoreDataMember()]
        public IFormFile FormFile { get; set; }
        public ICollection<BookModel> Books { get; set; }
        public AppFileFilterModel AppFileFilterModel { get; set; } = new AppFileFilterModel();
        public DateTime? Birthdate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
