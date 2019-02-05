using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/CategoryTagAssignment")]
    [Produces("application/json")]
    [AllowAnonymous]

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
                var isAny = await _categoryAssigment.GetTAsync(x => x.BookId == model.BookId);

                if (isAny != null)
                {
                    _categoryAssigment.Delete(isAny);
                }

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

        [HttpPost]
        [Route("Filter")]
        public List<CategoryModel> FilterSearch([FromBody]CategorySearchModel model)
        {
            List<CategoryModel> models = new List<CategoryModel>();
            var list = _categoryAssigment.GetList();

            foreach (var item in list)
            {
                CategoryModel categoryModel = new CategoryModel();
                if (model.CategoryIds.Count(x => x.Equals(item.CategoryId)) > 0 || model.AuthorIds.Count(y => y.Equals(item.AuthorId)) > 0 || model.PublisherId == item.PublisherId)
                {
                    if (models.Count==0)
                    {
                        categoryModel.Id = item.CategoryId;
                        categoryModel.Name = item.CategoryName;

                        MongoBookModel book = new MongoBookModel();
                        book.AuthorId = item.AuthorId;
                        book.AuthorName = item.AuthorName;
                        book.AuthorSurname = item.AuthorSurname;
                        book.BookName = item.BookName;
                        book.BookId = item.BookId;
                        book.SignUrl = item.SignUrl;

                        gelen filtreye göre category ve onun kitaplarını listele sorun şu ki hangi kategorinin kitaplarının hangi sırayla geleceğni bilmiyoruz.
                            düzenlemek gerekiyor.

                    }
                    else
                    {
                        
                    }
                }
            }
            return null;
        }
    }
}