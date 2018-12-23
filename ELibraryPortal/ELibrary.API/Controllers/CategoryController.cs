using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.API.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : APIControllerBase
    {
        private readonly ICategory _category;
        public IMapper _mapper;

        public CategoryController(ICategory category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public async Task<Response<List<CategoryModel>>> Get()
        {
            Response<List<CategoryModel>> categoryResponse = new Response<List<CategoryModel>>();
            List<Category> entityList = await _category.GetListAsync(x => x.IsActive == true);
            categoryResponse.Value =   _mapper.Map<List<CategoryModel>>(entityList);
            return categoryResponse;
        }

        [HttpPost("Save")]
        public async Task<Response<CategoryModel>> Post([FromBody]CategoryModel model)
        {
            Response<CategoryModel> categoryResponseModel = new Response<CategoryModel>();
            try
            {

                Category entity = _mapper.Map<Category>(model);
                entity = await (model.Id != Guid.Empty ? _category.UpdateAsync(entity) : _category.AddAsync(entity));
                categoryResponseModel.Value = _mapper.Map<CategoryModel>(entity);
                categoryResponseModel.IsSuccess = true;

            }
            catch (Exception e)
            {
                categoryResponseModel.Exception = e;
                categoryResponseModel.IsSuccess = false;              
            }

            return categoryResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public async Task<Response<CategoryModel>> GetOne(Guid id)
        {
            Response<CategoryModel> categoryResponse = new Response<CategoryModel>();
            Category entityList = await _category.GetTAsync(x => x.Id == id);
            categoryResponse.Value = _mapper.Map<CategoryModel>(entityList);

            return categoryResponse;

        }
    }
}