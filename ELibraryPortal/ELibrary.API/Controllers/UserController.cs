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
        private readonly IMongoUserRates _userRates;
        private readonly IMapper _mapper;

        public UserController(IMongoUserFavoritesAndReads mongoUserFavorites, IMongoUserRates userRates, IMapper mapper)
        {
            _mongoUserReadAndFavorites = mongoUserFavorites;
            _userRates = userRates;
            _mapper = mapper;
        }

        [HttpPost("Rate")]
        public async Task<ActionResult> Rate([FromBody]UserRateModel model)
        {
            try
            {
                if (model.Id != null)
                {
                    var filter = Builders<UserRates>.Filter.Eq("_id", ObjectId.Parse(model.Id));
                    var update = Builders<UserRates>.Update.Set("Rate", model.Rate);
                    var response = await _userRates.UpdateAsync(filter, update);
                }
                else
                {
                    UserRates entity = _mapper.Map<UserRates>(model);
                    var addedEntity = await _userRates.AddAsync(entity);
                }
            }
            catch (Exception e)
            {
                return StatusCode(403);
            }

            return StatusCode(200);
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
            List<UsersFavoritesAndReads> entities = _mongoUserReadAndFavorites.GetList(x => x.UserId == id);

            foreach (var item in entities)
            {
                foreach (var read in item.Reads)
                {
                    UserFavoriteAndReadModel readModel = _mapper.Map<UserFavoriteAndReadModel>(read);
                    reads.Add(readModel);
                }
                foreach (var read in item.Favorites)
                {
                    UserFavoriteAndReadModel readModel = _mapper.Map<UserFavoriteAndReadModel>(read);
                    favorites.Add(readModel);
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
            UsersFavoritesAndReads read = new UsersFavoritesAndReads();
            MongoBook mongoBookModel = new MongoBook();
            var filter = Builders<UsersFavoritesAndReads>.Filter.Eq("UserId", model.UserId);

            try
            {
                var entity = await _mongoUserReadAndFavorites.GetTAsync(filter);

                if (entity == null)
                {
                    mongoBookModel = _mapper.Map<MongoBook>(model);
                    read.UserId = model.UserId;
                    read.Reads.Add(mongoBookModel);
                    await _mongoUserReadAndFavorites.AddAsync(read);
                }
                else
                {
                    mongoBookModel = _mapper.Map<MongoBook>(model);
                    if (entity.Reads.FirstOrDefault(x => x.BookId == mongoBookModel.BookId) == null)
                    {
                        entity.Reads.Add(mongoBookModel);
                        var update = Builders<UsersFavoritesAndReads>.Update.Set("Reads", entity.Reads);
                        await _mongoUserReadAndFavorites.UpdateAsync(filter, update);
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
            UsersFavoritesAndReads read = new UsersFavoritesAndReads();
            MongoBook mongoBookModel = new MongoBook();
            var filter = Builders<UsersFavoritesAndReads>.Filter.Eq("UserId", model.UserId);

            try
            {
                var entity = await _mongoUserReadAndFavorites.GetTAsync(filter);

                if (entity == null)
                {
                    mongoBookModel = _mapper.Map<MongoBook>(model);
                    read.UserId = model.UserId;
                    read.Favorites.Add(mongoBookModel);
                    await _mongoUserReadAndFavorites.AddAsync(read);
                }
                else
                {
                    mongoBookModel = _mapper.Map<MongoBook>(model);


                    if (entity.Favorites.FirstOrDefault(x=>x.BookId==mongoBookModel.BookId)==null)
                    {
                        entity.Reads.Add(mongoBookModel);
                        var update = Builders<UsersFavoritesAndReads>.Update.Set("Favorites", entity.Favorites);
                        await _mongoUserReadAndFavorites.UpdateAsync(filter, update);
                    }
                    else
                    {
                        int index = entity.Favorites.FindIndex(a => a.BookId == mongoBookModel.BookId);
                        entity.Favorites.RemoveAt(index);
                        var update = Builders<UsersFavoritesAndReads>.Update.Set("Favorites", entity.Favorites);
                        await _mongoUserReadAndFavorites.UpdateAsync(filter, update);

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