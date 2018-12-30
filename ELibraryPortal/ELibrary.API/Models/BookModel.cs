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

namespace ELibrary.API.Models
{
    public class BookModel : ModelBase<Guid>, IModelBase
    {
        private readonly IAppFile _appFile;
        private IMapper _mapper;
        //private ICollection<AppFileModel> _appFiles;
        //private ICollection<AppFileModel> _thumbnail;
        public BookModel()
        {
            _appFile = new EFAppFile();
            _mapper = DIManager.Instance.Provider.GetService<IMapper>();
        }

        public string BookName { get; set; }
        public string BookSummary { get; set; }
        public Guid AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime EditionDate { get; set; }
        public int NumberPage { get; set; }
        public Base64FormattingOptions BookPhoto { get; set; }
        public bool IsActive { get; set; } = true;
        public AppFileModel Thumbnail
        {
            get
            {
                return _mapper.Map<AppFileModel>(_appFile.GetT(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.BookThumbnail)));
            }
        }
        public ICollection<AppFileModel> AppFiles
        {
            get
            {
                _mapper = DIManager.Instance.Provider.GetService<IMapper>();
                return _appFile.GetList(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.Publication)).
                    Select(f=> new AppFileModel 
                    {
                        BlobPath = f.BlobPath,
                        FilePath = f.FilePath,
                        Id = f.Id,
                        Extension = f.Extension,
                        ModuleId = f.ModuleId,
                        ModuleType = Enum.Enum.Module.Publication,
                        Name = f.Name,
                        UniqueName = f.UniqueName
                    }).ToList();
            }
        }
        public Guid PublisherId { get; set; }
        public List<PublisherModel> Publisher { get; set; }
        public List<AuthorModel> AuthorModel { get; set; }
    }
}
