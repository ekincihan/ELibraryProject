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

        [HttpPost]
        [Route("ReadBook")]
        public async Task<ActionResult> ReadBook([FromBody]UserFavoriteAndReadModel model)
        {
            try
            {
                var entity = await _mongoUserReadAndFavorites.GetTAsync(x => x.UserId == model.UserId);
                if (entity == null)
                {
                    UsersFavoritesAndReads read = new UsersFavoritesAndReads();
                    MongoBook mongoBookModel = _mapper.Map<MongoBook>(model);
                    read.UserId = model.UserId;
                    read.Reads.Add(mongoBookModel);
                    await _mongoUserReadAndFavorites.AddAsync(read);
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
            try
            {
                var entity = await _mongoUserReadAndFavorites.GetTAsync(x => x.UserId == model.UserId);
                if (entity == null)
                {
                    UsersFavoritesAndReads read = new UsersFavoritesAndReads();
                    MongoBook mongoBookModel = _mapper.Map<MongoBook>(model);
                    read.UserId = model.UserId;
                    read.Favorites.Add(mongoBookModel);
                    await _mongoUserReadAndFavorites.AddAsync(read);
                }
                //else
                //{
                //    var filter = Builders<UserRates>.Filter.Eq("_id", (model.Id)); 
                //    var update = Builders<UserRates>.Update.Set("Rate", model.Rate);
                //    var response = await _userRates.UpdateAsync(filter, update);
                //}

            }
            catch (Exception e)
            {
                return StatusCode(404);
            }

            return StatusCode(200);
        }
    }
}