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
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.API.Models
{
    public class BookModel : ModelBase<Guid>, IModelBase
    {
        private readonly IAppFile _appFile;
        private readonly IPublisher _publisher;
        private readonly IAuthor _author;
        private readonly ICategory _category;
        private readonly ICategoryTagAssignment _categoryTagAssignment;
        private IMapper _mapper;
        //private ICollection<AppFileModel> _appFiles;
        //private ICollection<AppFileModel> _thumbnail;
        public BookModel()
        {
            _appFile = new EFAppFile();
            _publisher = new EFPublisher();
            _author = new EFAuthor();
            _category = new EFCategory();
            _categoryTagAssignment = new EFCategoryTagAssigment();
            _mapper = DIManager.Instance.Provider.GetService<IMapper>();
        }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string BookName { get; set; }
        public string BookSummary { get; set; }
        public Guid AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime EditionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int NumberPages { get; set; }
        public Base64FormattingOptions BookPhoto { get; set; }
        public string [] TagIds
        {
            get
            {
                return _categoryTagAssignment.GetList(x => x.BookId == this.Id).Select(x => x.TagId).ToArray<string>();
            }
        }
        public bool IsActive { get; set; } = true;
        public AppFileModel Thumbnail
        {
            get
            {
                //var mdata = _appFile.GetList();
                //var csd = _appFile.GetList(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.BookThumbnail));
                _mapper = DIManager.Instance.Provider.GetService<IMapper>();
                return _appFile.GetList(x => x.ModuleId == this.Id && x.ModuleType == (int)(Enum.Enum.Module.BookThumbnail)).
                    Select(f => new AppFileModel
                    {
                        BlobPath = f.BlobPath,
                        FilePath = f.FilePath,
                        Id = f.Id,
                        Extension = f.Extension,
                        ModuleId = f.ModuleId,
                        ModuleType = Enum.Enum.Module.Publication,
                        Name = f.Name,
                        UniqueName = f.UniqueName,
                        SignUrl = f.SignUrl
                    }).FirstOrDefault();

            }
        }
        public ICollection<AppFileModel> AppFiles
        {
            get
            {
                _mapper = DIManager.Instance.Provider.GetService<IMapper>();
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
                        UniqueName = f.UniqueName,
                        SignUrl = f.SignUrl
                    }).ToList();
            }
        }
        public Guid CategoryId { get; set; }
        
        public int ReadCount { get; set; }

        public CategoryModel Category
        {
            get
            {
                Category entity = _category.GetT(x => x.IsActive == true && x.Id == this.CategoryId);
                if (entity != null)
                {
                    CategoryModel model = new CategoryModel()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        IsActive = entity.IsActive
                    };
                    return model;
                }
                else
                {
                    return new CategoryModel();
                }
            }
        }
        public Guid PublisherId { get; set; }
        public PublisherModel Publisher
        {
            get
            {
                Publisher entity = _publisher.GetT(x => x.IsActive == true && x.Id == this.PublisherId);
                if (entity != null)
                {
                    PublisherModel model = new PublisherModel()
                    {
                        Id = entity.Id,
                        Email = entity.Email,
                        IsActive = entity.IsActive,
                        Name = entity.Name,
                    };
                    return model;
                }
                else
                {
                    return new PublisherModel();
                }

            }
        }

        public AuthorModel Author
        {
            get
            {
                Author entity = _author.GetT(x => x.IsActive == true && x.Id == this.AuthorId);
                if (entity != null)
                {
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
                else
                {
                    return new AuthorModel();
                }

            }
        }
        public CategoryTagAssigmentModel CategoryTagAssigment { get; set; }

    }
}
