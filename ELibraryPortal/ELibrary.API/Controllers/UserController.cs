using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
using ELibrary.DAL.Abstract;
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
    public class UserController : ControllerBase
    {
        private readonly IMongoUserFavoritesAndReads _mongoUserFavorites;
        private readonly IMongoUserRates _userRates;
        private readonly IMapper _mapper;

        public UserController(IMongoUserFavoritesAndReads mongoUserFavorites, IMongoUserRates userRates, IMapper mapper)
        {
            _mongoUserFavorites = mongoUserFavorites;
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


        [HttpPost("Rate")]
        public ActionResult GetRates(string userId)
        {
            List<UserRates> rates =  _userRates.GetList(null);
            return null;
        }
    }
}