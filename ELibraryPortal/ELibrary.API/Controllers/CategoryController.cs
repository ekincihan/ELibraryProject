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
        private readonly ICategoryTagAssignment _categoryAssigment;
        private readonly IAuthor _author;
        private readonly IBooks _book;

        public IMapper _mapper;

        public CategoryController(ICategory category, IMapper mapper, ICategoryTagAssignment categoryAssigment, IBooks book, IAuthor author)
        {
            _category = category;
            _mapper = mapper;
            _categoryAssigment = categoryAssigment;
            _book = book;
            _author = author;
        }

        [HttpGet("List")]
        public async Task<Response<List<CategoryModel>>> Get()
        {
            Response<List<CategoryModel>> categoryResponse = new Response<List<CategoryModel>>();
            List<Category> entityList = await _category.GetListAsync(x => x.IsActive == true);
            categoryResponse.Value = _mapper.Map<List<CategoryModel>>(entityList);
            return categoryResponse;
        }

        [HttpGet("CategoryBook")]
        public List<CategoryModel> CategoryBook()
        {
            List<CategoryTagAssigment> categoriesBook = _categoryAssigment.GetList();
            var categoriesId = categoriesBook.GroupBy(x => x.CategoryId).Select(x => x.FirstOrDefault()).ToList();

            List<CategoryModel> returnModel = new List<CategoryModel>();

            foreach (var category in categoriesId.ToList())
            {
                CategoryModel categoryModel = new CategoryModel();
                foreach (var item in categoriesBook.Where(x => x.CategoryId == category.CategoryId))
                {
                    MongoBookModel model = new MongoBookModel();
                    model.CategoryId = item.CategoryId;
                    model.CategoryName = item.CategoryName;
                    model.BookId = item.BookId;
                    model.BookName = item.BookName;
                    model.SignUrl = item.SignUrl;
                    model.AuthorId = item.AuthorId;
                    model.AuthorName = item.AuthorName;
                    model.AuthorSurname = item.AuthorSurname;
                    //model.PublisherId = item.PublisherId;
                    //model.PublisherName=item.PublisherName

                    categoryModel.Books.Add(model);
                }

                categoryModel.Id = category.CategoryId;
                categoryModel.Name = category.CategoryName;
                returnModel.Add(categoryModel);
            }

            return returnModel;
        }

        [HttpGet]
        [Route("BookByCategory/{id}")]
        public List<CategoryModel> BookByCategory(Guid id)
        {
            List<CategoryTagAssigment> categoriesBook = _categoryAssigment.GetList(x => x.CategoryId == id);
            var categoriesId = categoriesBook.GroupBy(x => x.CategoryId).Select(x => x.FirstOrDefault()).ToList();

            List<CategoryModel> returnModel = new List<CategoryModel>();

            foreach (var category in categoriesId.ToList())
            {
                CategoryModel categoryModel = new CategoryModel();
                foreach (var item in categoriesBook.Where(x => x.CategoryId == category.CategoryId))
                {
                    MongoBookModel model = new MongoBookModel();
                    model.CategoryId = item.CategoryId;
                    model.CategoryName = item.CategoryName;
                    model.BookId = item.BookId;
                    model.BookName = item.BookName;
                    model.SignUrl = item.SignUrl;
                    model.AuthorId = item.AuthorId;
                    model.AuthorName = item.AuthorName;
                    model.AuthorSurname = item.AuthorSurname;

                    categoryModel.Books.Add(model);
                }

                categoryModel.Id = category.CategoryId;
                categoryModel.Name = category.CategoryName;
                returnModel.Add(categoryModel);
            }


            return returnModel;
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