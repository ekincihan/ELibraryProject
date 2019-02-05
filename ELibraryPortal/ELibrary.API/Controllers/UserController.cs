using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
using ELibrary.DAL.Abstract;
using ELibrary.DAL.Concrete.MongoDB;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IMongoUserFavoritesAndReads _mongoUserReadAndFavorites;
        private readonly IUserRates _userRates;
        private readonly IMapper _mapper;
        private readonly IUserFavoriteAndReadBook _userFavoriteAndReadBook;
        private readonly IBooks _books;
        private readonly IAuthor _authors;
        private readonly IAppFile _appFile;
        private readonly IUserReadPage _userReadPage;

        public UserController(IMongoUserFavoritesAndReads mongoUserFavorites, IMapper mapper, IUserFavoriteAndReadBook userFavoriteAndReadBook, IBooks books, IAuthor authors, IAppFile appFile, IUserRates userRates, IUserReadPage userReadPage)
        {
            _mongoUserReadAndFavorites = mongoUserFavorites;
            _mapper = mapper;
            _userFavoriteAndReadBook = userFavoriteAndReadBook;
            _books = books;
            _authors = authors;
            _appFile = appFile;
            _userRates = userRates;
            _userReadPage = userReadPage;
        }

        [HttpPost("Rate")]
        public async Task<string> Rate([FromBody]UserRateModel model)
        {
            try
            {
                if (model.Id != null)
                {
                    var entity = await _userRates.GetTAsync(x => x.Id == new Guid(model.Id));
                    entity.Rate = model.Rate;
                    var response = await _userRates.UpdateAsync(entity);
                }
                else
                {
                    UserRates entity = _mapper.Map<UserRates>(model);
                    var addedEntity = await _userRates.AddAsync(entity);
                    return addedEntity.Id.ToString();
                }
            }
            catch (Exception e)
            {
                return "403";
            }

            return model.Id;
        }

        [HttpPost]
        [Route("ReadPage")]
        public async Task<UserReadPageModel> ReadPage([FromBody]UserReadPageModel model)
        {
            try
            {
                if (model.Id != Guid.Empty)
                {
                    var entity = await _userReadPage.GetTAsync(x => x.Id == model.Id);
                    entity.Page = model.Page;
                    await _userReadPage.UpdateAsync(entity);
                    UserReadPageModel returnModel = _mapper.Map<UserReadPageModel>(entity);
                    return returnModel;
                }
                else
                {
                    UserReadPage entity = _mapper.Map<UserReadPage>(model);
                    var addedEntity = await _userReadPage.AddAsync(entity);
                    UserReadPageModel returnModel = _mapper.Map<UserReadPageModel>(addedEntity);
                    return returnModel;

                }
            }
            catch (Exception e)
            {
            }

            return null;
        }

        [HttpPost]
        [Route("UserReadPage")]
        public UserReadPageModel GetReadPage([FromBody]UserReadPageModel model)
        {
            var entity = _userReadPage.GetT(x => x.UserId == model.UserId && x.BookId == model.BookId);
            UserReadPageModel returnModel = _mapper.Map<UserReadPageModel>(entity);
            return returnModel;
        }

        [HttpGet]
        [Route("Rate/{id}")]
        public List<UserRateModel> GetRates(Guid id)
        {
            List<UserRates> rates = _userRates.GetList(x => x.UserId == id);
            List<UserRateModel> models = _mapper.Map<List<UserRateModel>>(rates);

            return models;
        }

        [HttpGet]
        [Route("GetFavAndReads/{id}")]
        public UserFavoriteAndReadResponseModel GetFavAndReads(Guid id)
        {
            UserFavoriteAndReadResponseModel model = new UserFavoriteAndReadResponseModel();
            List<UserFavoriteAndReadModel> reads = new List<UserFavoriteAndReadModel>();
            List<UserFavoriteAndReadModel> favorites = new List<UserFavoriteAndReadModel>();
            List<UserFavoritAndReadBook> entities = _userFavoriteAndReadBook.GetList(x => x.UserId == id);
            List<Book> books = _books.GetList();
            List<AppFile> files = _appFile.GetList();
            List<Author> authors = _authors.GetList();

            foreach (var item in entities.Where(x => x.Type == UserFavAndRead.Reads))
            {
                UserFavoriteAndReadModel readModel = new UserFavoriteAndReadModel();
                var entity = books.FirstOrDefault(x => x.Id == item.BookId);
                if (entity != null)
                {
                    readModel.BookId = entity.Id;
                    readModel.UserId = item.UserId;
                    readModel.AuthorId = entity.AuthorId;
                    readModel.AuthorName = authors.FirstOrDefault(x => x.Id == entity.AuthorId).Name;
                    readModel.AuthorSurname = authors.FirstOrDefault(x => x.Id == entity.AuthorId).Surname;
                    readModel.SignUrl = "https://elibrarystorage.blob.core.windows.net/" + files.FirstOrDefault(x => x.ModuleId == entity.Id).BlobPath;
                    reads.Add(readModel);
                }
            }

            foreach (var item in entities.Where(x => x.Type == UserFavAndRead.Favorite))
            {
                UserFavoriteAndReadModel favoriteModel = new UserFavoriteAndReadModel();
                var entity = books.FirstOrDefault(x => x.Id == item.BookId);
                if (entity != null)
                {
                    favoriteModel.BookId = entity.Id;
                    favoriteModel.UserId = item.UserId;
                    favoriteModel.AuthorId = entity.AuthorId;
                    favoriteModel.AuthorName = authors.FirstOrDefault(x => x.Id == entity.AuthorId).Name;
                    favoriteModel.AuthorSurname = authors.FirstOrDefault(x => x.Id == entity.AuthorId).Surname;
                    favoriteModel.SignUrl = files.FirstOrDefault(x => x.ModuleId == entity.Id).BlobPath;
                    favorites.Add(favoriteModel);
                }
            }

            model.Favorites = favorites;
            model.Reads = reads;

            return model;
        }

        [HttpPost]
        [Route("ReadBook")]
        public async Task<ActionResult> ReadBook([FromBody]UserFavoriteAndReadModel model)
        {
            //UsersFavoritesAndReads read = new UsersFavoritesAndReads();
            //MongoBook mongoBookModel = new MongoBook();
            //var filter = Builders<UsersFavoritesAndReads>.Filter.Eq("UserId", model.UserId);

            UserFavoritAndReadBook read = new UserFavoritAndReadBook();

            try
            {
                var entity = await _userFavoriteAndReadBook.GetListAsync(x => x.UserId == model.UserId);

                if (entity.Count == 0)
                {
                    read.UserId = model.UserId;
                    read.BookId = model.BookId;
                    read.Type = UserFavAndRead.Reads;
                    await _userFavoriteAndReadBook.AddAsync(read);
                }
                else
                {
                    if (entity.FirstOrDefault(x => x.BookId == model.BookId) == null)
                    {
                        read.UserId = model.UserId;
                        read.BookId = model.BookId;
                        read.Type = UserFavAndRead.Reads;
                        await _userFavoriteAndReadBook.AddAsync(read);
                    }

                }
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }

            return StatusCode(200);
        }

        [HttpPost]
        [Route("Favorite")]
        public async Task<ActionResult> Favorite([FromBody]UserFavoriteAndReadModel model)
        {
            //UsersFavoritesAndReads read = new UsersFavoritesAndReads();
            //MongoBook mongoBookModel = new MongoBook();
            //var filter = Builders<UsersFavoritesAndReads>.Filter.Eq("UserId", model.UserId);
            UserFavoritAndReadBook favorite = new UserFavoritAndReadBook();

            try
            {
                var entity = await _userFavoriteAndReadBook.GetListAsync(x => x.UserId == model.UserId);

                if (entity.Count == 0)
                {
                    favorite.UserId = model.UserId;
                    favorite.BookId = model.BookId;
                    favorite.Type = UserFavAndRead.Favorite;
                    await _userFavoriteAndReadBook.AddAsync(favorite);
                }
                else
                {

                    if (entity.FirstOrDefault(x => x.BookId == model.BookId && x.Type == UserFavAndRead.Favorite) == null)
                    {
                        favorite.UserId = model.UserId;
                        favorite.BookId = model.BookId;
                        favorite.Type = UserFavAndRead.Favorite;
                        await _userFavoriteAndReadBook.AddAsync(favorite);
                    }
                    else
                    {
                        var deletingEntity = entity.FirstOrDefault(x => x.BookId == model.BookId);
                        _userFavoriteAndReadBook.Delete(deletingEntity);
                    }

                }
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }

            return StatusCode(200);
        }
    }
}