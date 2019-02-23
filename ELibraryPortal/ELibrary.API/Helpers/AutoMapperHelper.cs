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

            #region Book
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>();
            #endregion

            #region Files
            CreateMap<AppFile, AppFileModel>();
            CreateMap<AppFileModel, AppFile>();
            #endregion

            #region CategoryTagAssigment
            CreateMap<CategoryTagAssigment, CategoryTagAssigmentModel>();
            CreateMap<CategoryTagAssigmentModel, CategoryTagAssigment>();
            #endregion

            #region UserRate
            CreateMap<UserRates, UserRateModel>();
            CreateMap<UserRateModel, UserRates>();

            #endregion
            
            #region UserReadPage
            CreateMap<UserReadPage, UserReadPageModel>();
            CreateMap<UserReadPageModel, UserReadPage>();

            #endregion

            #region Contact
            CreateMap<Contact, ContactModel>();
            CreateMap<ContactModel, Contact>();

            #endregion

            #region FavoriteAndRate
            CreateMap<MongoBook, UserFavoriteAndReadModel>();
            CreateMap<UserFavoriteAndReadModel, MongoBook>();
            #endregion


            #region About
            CreateMap<About, AboutModel>();
            CreateMap<AboutModel, About>();
            #endregion
        }
    }
}
