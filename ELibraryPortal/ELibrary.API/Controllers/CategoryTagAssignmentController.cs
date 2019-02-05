using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/CategoryTagAssignment")]
    public class CategoryTagAssignmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly IMongoTagCategoryAssigment _categoryAssigment;
        private readonly ICategoryTagAssignment _categoryAssigment;

        public CategoryTagAssignmentController(IMapper mapper, ICategoryTagAssignment categoryAssigment)
        {
            _mapper = mapper;
            _categoryAssigment = categoryAssigment;
        }

        [HttpGet]
        [Route("List")]
        public Response<List<CategoryTagAssigmentModel>> Get()
        {
            Response<List<CategoryTagAssigmentModel>> categoryTagResponse = new Response<List<CategoryTagAssigmentModel>>();
            List<CategoryTagAssigment> entityList = _categoryAssigment.GetList(x => x.IsActive == true);
            categoryTagResponse.Value = _mapper.Map<List<CategoryTagAssigmentModel>>(entityList);

            return categoryTagResponse;
        }


        [HttpPost]
        [Route("Save")]
        public async Task<Response<CategoryTagAssigmentModel>> Post([FromBody]CategoryTagAssigmentModel model)
        {
            Response<CategoryTagAssigmentModel> CategoryTagAssigmentModel = new Response<CategoryTagAssigmentModel>();
            try
            {
                //var filter = Builders<CategoryTagAssigment>.Filter.Eq("BookId", model.BookId);
                //var entit1y = await _categoryAssigment.GetTAsync(filter);

                //_categoryAssigment.Delete(filter);

                CategoryTagAssigment entity = _mapper.Map<CategoryTagAssigment>(model);
                entity = await _categoryAssigment.AddAsync(entity);
                CategoryTagAssigmentModel.Value = _mapper.Map<CategoryTagAssigmentModel>(entity);
                CategoryTagAssigmentModel.IsSuccess = true;
            }
            catch (Exception e)
            {
                CategoryTagAssigmentModel.Exception = e;
                CategoryTagAssigmentModel.IsSuccess = false;
            }

            return CategoryTagAssigmentModel;
        }


    }
}