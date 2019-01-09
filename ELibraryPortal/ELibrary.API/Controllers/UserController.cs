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
                UserRates entity = _mapper.Map<UserRates>(model);
                //entity = await(model.Id != Guid.Empty ? _userRates.UpdateAsync(entity) : _userRates.AddAsync(entity));
                entity = await _userRates.AddAsync(entity);
            }
            catch (Exception e)
            {
                return StatusCode(403);
            }

            return StatusCode(200);
        }


    }
}