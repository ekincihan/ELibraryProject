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
using ELibrary.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;

namespace ELibrary.API.Models
{
    public class BookModel : ModelBase<Guid>, IModelBase
    {
        private readonly IAppFile _appFile;
        private readonly IPublisher _publisher;
        private readonly IAuthor _author;
        private IMapper _mapper;
        //private ICollection<AppFileModel> _appFiles;
        //private ICollection<AppFileModel> _thumbnail;
        public BookModel()
        {
            _appFile = new EFAppFile();
            _publisher = new EFPublisher();
            _author = new EFAuthor();
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
                AppFileModel model= new AppFileModel();
                AppFile entiy = _appFile.GetT(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.BookThumbnail));
                if (entiy!=null)
                {
                    model = new AppFileModel()
                    {
                        Id = entiy.Id,
                        BlobPath = entiy.BlobPath,
                        Name = entiy.Name,
                        Extension = entiy.Extension,
                        FilePath = entiy.FilePath,
                        ModuleId = entiy.ModuleId,
                        ModuleType = (Enum.Enum.Module)entiy.ModuleType,
                        UniqueName = entiy.UniqueName
                    };
                }
            

                return model;

            }
        }   
        public ICollection<AppFileModel> AppFiles
        {
            get
            {
                return _appFile.GetList(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.Publication)).
                    Select(f => new AppFileModel
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

        public PublisherModel Publisher
        {
            get
            {
                Publisher entity = _publisher.GetT(x => x.IsActive == true && x.Id == this.PublisherId);
                PublisherModel model = new PublisherModel()
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    IsActive = entity.IsActive,
                    Name = entity.Name,
                };
                return model;
            }
        }

        public AuthorModel Author
        {
            get
            {
                Author entity = _author.GetT(x => x.IsActive == true && x.Id == this.AuthorId);
                AuthorModel model = new AuthorModel()
                {
                    Id = entity.Id,
                    IsActive = entity.IsActive,
                    Name = entity.Name,
                    Gender = entity.Gender,
                    Biography = entity.Biography,
                    Birthdate = entity.Birthdate,
                    Surname = entity.Surname
                };
                return model;
            }
        }
    }
}
