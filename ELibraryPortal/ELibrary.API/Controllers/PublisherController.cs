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
using MongoDB.Driver;

namespace ELibrary.API.Controllers
{
    [Route("api/Publisher")]
    [ApiController]
    public class PublisherController : APIControllerBase
    {
        private static readonly char[] Letters =
            "ABCÇDEFGHIİJKLMNOÖPQRSTUÜVWXYZ".ToCharArray();

        private readonly IPublisher _publisher;
        private readonly ICategoryTagAssignment _categoryAssigment;

        private readonly IMapper _mapper;
        private readonly IBooks _books;

        public PublisherController(IPublisher publisher, IMapper mapper, ICategoryTagAssignment categoryAssigment,IBooks books)
        {
            _publisher = publisher;
            _mapper = mapper;
            _categoryAssigment = categoryAssigment;
            _books = books;
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

            var list = _publisher.GetList(x=>x.IsActive==true).ToList();
            var groupedByLetter =
                from letter in Letters
                join service in list on letter equals service.Name[0] into grouped
                select new { Letter = letter, list = grouped };

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
                Publisher entityT = _mapper.Map<Publisher>(model);
                entityT = _publisher.GetT(x => x.Name.Trim() == entityT.Name.Trim());
                if (model.Id!=Guid.Empty)
                {
                    entity = await (model.Id != Guid.Empty ? _publisher.UpdateAsync(entity) : _publisher.AddAsync(entity));
                    if (model.Id != Guid.Empty && model.IsActive == false)
                    {
                        List<Book> entityList = await _books.GetListAsync( x=>x.PublisherId == model.Id);
                        List<CategoryTagAssigment> categoryTagAssigmentsentityList= await _categoryAssigment.GetListAsync(x=>x.PublisherId == model.Id);

                        foreach (var item in entityList)
                        {
                            item.IsActive = false;
                            _books.Update(item);

                        }
                        foreach (var item2 in categoryTagAssigmentsentityList)
                        {
                            item2.IsActive = false;
                            _categoryAssigment.Update(item2);
                            
                        }
                    }
                    publisherResponseModel.Value = _mapper.Map<PublisherModel>(entity);
                    publisherResponseModel.IsSuccess = true;
                }
                else if (model.Id==Guid.Empty && entityT==null)
                {
                    entity = await (model.Id != Guid.Empty ? _publisher.UpdateAsync(entity) : _publisher.AddAsync(entity));
                    publisherResponseModel.Value = _mapper.Map<PublisherModel>(entity);
                    publisherResponseModel.IsSuccess = true;
                }
              else
                {
                    publisherResponseModel.Message = "Aynı Isimli Yayınevi Mevcut";
                    publisherResponseModel.IsSuccess = false;
                }
            }
            catch (Exception e)
            {
                publisherResponseModel.Message = "Bir Hata Oluştu";
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
        [Route("BookByPublisher/{id}")]
        public List<CategoryModel> BookByPublisher(Guid id)
        {
            #region publisherTempSilinecek
            //List<CategoryTagAssigment> categasdoriesBook = _categoryAssigment.GetList();

            //string cate = "Doğan Kitap";
            //foreach (var item in categasdoriesBook)
            //{
            //    if (item.PublisherName == cate)
            //    {
            //        var filter = Builders<CategoryTagAssigment>.Filter.Eq("BookName", item.BookName);
            //        var update = Builders<CategoryTagAssigment>.Update.Set("PublisherId", "E86B40EA-DDB1-4525-F26D-08D6700D8555");
            //         _categoryAssigment.Update(filter, update);

            //    }

            //}

            //string c1ate = "Sel Yayıncılık";
            //foreach (var item in categasdoriesBook)
            //{
            //    if (item.PublisherName == c1ate)
            //    {
            //        var filter = Builders<CategoryTagAssigment>.Filter.Eq("BookName", item.BookName);
            //        var update = Builders<CategoryTagAssigment>.Update.Set("PublisherId", "7C05CB67-6734-4DE8-F4BF-08D670143054");
            //        _categoryAssigment.Update(filter, update);

            //    }

            //}

            //string c1aaste = "İletişim Yayıncılık";
            //foreach (var item in categasdoriesBook)
            //{
            //    if (item.PublisherName == c1aaste)
            //    {
            //        var filter = Builders<CategoryTagAssigment>.Filter.Eq("BookName", item.BookName);
            //        var update = Builders<CategoryTagAssigment>.Update.Set("PublisherId", "07E16C53-B86A-4EF1-F4C0-08D670143054");
            //        _categoryAssigment.Update(filter, update);

            //    }

            //}

            //string assdasdas = "İthaki Yayınları";
            //foreach (var item in categasdoriesBook)
            //{
            //    if (item.PublisherName == assdasdas)
            //    {
            //        var filter = Builders<CategoryTagAssigment>.Filter.Eq("BookName", item.BookName);
            //        var update = Builders<CategoryTagAssigment>.Update.Set("PublisherId", "4274AAC6-8CE1-44FB-F4C2-08D670143054");
            //        _categoryAssigment.Update(filter, update);

            //    }

            //}

            //string asassdasdas = "Yapı Kredi Yayınları";
            //foreach (var item in categasdoriesBook)
            //{
            //    if (item.PublisherName == asassdasdas)
            //    {
            //        var filter = Builders<CategoryTagAssigment>.Filter.Eq("BookName", item.BookName);
            //        var update = Builders<CategoryTagAssigment>.Update.Set("PublisherId", "44046DC0-86DF-4B58-F4C1-08D670143054");
            //        _categoryAssigment.Update(filter, update);

            //    }

            //}



            #endregion

            List<CategoryTagAssigment> categoriesBook = _categoryAssigment.GetList(x => x.PublisherId == id && x.IsActive == true);
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