using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
using ELibrary.Entities.Concrete;

namespace ELibrary.API.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            #region PublisherController
            CreateMap<PublisherModel, Publisher>();
            CreateMap<Publisher, PublisherModel>();
            #endregion

            #region CategoryController
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
            #endregion

            #region AppFileController
            CreateMap<AppFile, AppFileModel>();
            CreateMap<AppFileModel, AppFile>();
            #endregion

            #region TypeController
            CreateMap<AppType, TypeModel>();
            CreateMap<TypeModel, AppType>();

            #endregion

            #region TypeController
            CreateMap<Tag, TagModel>();
            CreateMap<TagModel, Tag>();

            #endregion

            #region Author
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();
            #endregion

        
        }
    }
}
