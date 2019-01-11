using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.DAL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ELibrary.API.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMongoTagCategoryAssigment _mongoTagCategory;

        public SearchController(IMongoTagCategoryAssigment mongoTagCategory)
        {
            _mongoTagCategory = mongoTagCategory;
        }

        [HttpGet("Get")]
        public void Result([FromBody]string searchKey)
        {

            var entity = _mongoTagCategory.Search(searchKey);

            //return null/*;*/
        }
    }
}