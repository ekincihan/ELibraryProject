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
    [Route("api/Publisher")]
    [ApiController]
    public class PublisherController : APIControllerBase
    {
        private static readonly char[] Letters =
            "ABCÇDEFGHIİJKLMNOÖPQRSTUÜVWXYZ".ToCharArray();

        private readonly IPublisher _publisher;
        private readonly IMongoTagCategoryAssigment _categoryAssigment;

        private readonly IMapper _mapper;

        public PublisherController(IPublisher publisher, IMapper mapper, IMongoTagCategoryAssigment categoryAssigment)
        {
            _publisher = publisher;
            _mapper = mapper;
            _categoryAssigment = categoryAssigment;
        }

        [HttpGet]
        [Route("List")]
        public Response<List<PublisherModel>> Get()
        {
            Response<List<PublisherModel>> publisherResponse = new Response<List<PublisherModel>>();
            List<Publisher> entityList = _publisher.GetList(x => x.IsActive == true);
            publisherResponse.Value = _mapper.Map<List<PublisherModel>>(entityList);

            return publisherResponse;
        }

        [HttpGet]
        [Route("Alphabetically")]
        public List<PublisherUiModel> AlphabeticalList()
        {
            List<PublisherUiModel> responseModel = new List<PublisherUiModel>();
            List<PublisherModel> alphabeticList = new List<PublisherModel>();

            var list = _publisher.GetList().ToList();
            var groupedByLetter =
                from letter in Letters
                join service in list on letter equals service.Name[0] into grouped
                select new {Letter = letter, list = grouped};

            foreach (var entry in groupedByLetter)
            {
                alphabeticList = new List<PublisherModel>();
                PublisherUiModel UiModel = new PublisherUiModel();
                UiModel.Character = entry.Letter.ToString();

                foreach (var service in entry.list)
                {
                    PublisherModel model = new PublisherModel();
                    model.Name = service.Name;
                    model.Id = service.Id;
                    alphabeticList.Add(model);
                }

                if (alphabeticList.Count > 0)
                {
                    UiModel.AlphabeticalList = alphabeticList;
                    responseModel.Add(UiModel);
                }
            }


            return responseModel;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<Response<PublisherModel>> Post([FromBody] PublisherModel model)
        {
            Response<PublisherModel> publisherResponseModel = new Response<PublisherModel>();
            try
            {
                Publisher entity = _mapper.Map<Publisher>(model);
                entity = await (model.Id != Guid.Empty ? _publisher.UpdateAsync(entity) : _publisher.AddAsync(entity));
                publisherResponseModel.Value = _mapper.Map<PublisherModel>(entity);
                publisherResponseModel.IsSuccess = true;
            }
            catch (Exception e)
            {
                publisherResponseModel.Exception = e;
                publisherResponseModel.IsSuccess = false;
            }

            return publisherResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public Response<PublisherModel> GetOne(Guid id)
        {
            Response<PublisherModel> publisherResponse = new Response<PublisherModel>();
            Publisher entityList = _publisher.GetT(x => x.Id == id);
            publisherResponse.Value = _mapper.Map<PublisherModel>(entityList);

            return publisherResponse;
        }

        [HttpGet]
        [Route("CategoryBook/{id}")]
        public List<CategoryModel> BookByPublisher(Guid id)
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
                    model.PublisherId = item.PublisherId;
                    model.PublisherName = item.PublisherName;

                    categoryModel.Books.Add(model);
                }

                categoryModel.Id = category.CategoryId;
                categoryModel.Name = category.CategoryName;
                returnModel.Add(categoryModel);
            }

            return returnModel;
        }

    }
}