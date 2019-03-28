using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : APIControllerBase
    {

        private readonly IAuthor _author;
        private readonly IBooks _book;

        private IMapper _mapper;

        private static readonly char[] Letters =
            "ABCÇDEFGHIİJKLMNOÖPQRSTUÜVWXYZ".ToCharArray();

        public AuthorController(IAuthor author, IMapper mapper, IBooks book)
        {
            _author = author;
            _mapper = mapper;
            _book = book;
        }

        [HttpGet]
        [Route("List")]
        public Response<List<AuthorModel>> Get()
        {
            Response<List<AuthorModel>> authorResponse = new Response<List<AuthorModel>>();
            List<Author> entityList = _author.GetList(x => x.IsActive == true);
            authorResponse.Value = _mapper.Map<List<AuthorModel>>(entityList);

            return authorResponse;
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public Response<AuthorModel> AuthorDetail(Guid id)
        {
            Response<AuthorModel> authorResponse = new Response<AuthorModel>();
            Author entity = _author.GetT(x => x.Id == id &&x.IsActive==true);
            authorResponse.Value = _mapper.Map<AuthorModel>(entity);

            return authorResponse;
        }


        [HttpGet]
        [Route("Books/{id}")]
        public Response<List<BookModel>> AuthorBooks(Guid id)
        {

            Response<List<BookModel>> bookResponse = new Response<List<BookModel>>();
            List<Book> entityList = _book.GetList(x => x.AuthorId == id && x.IsActive == true);
            bookResponse.Value = _mapper.Map<List<BookModel>>(entityList.OrderByDescending(f => f.CreatedDate)).ToList();

            return bookResponse;
        }


        [HttpPost]
        [Route("Save")]
        public async Task<Response<AuthorModel>> Post([FromBody]AuthorModel model)
        {
            Response<AuthorModel> authorResponseModel = new Response<AuthorModel>();
            try
            {


                Author entity = _mapper.Map<Author>(model);
                Author entityT = _mapper.Map<Author>(model);
                entityT = _author.GetT(x => x.Name.Trim() == entityT.Name.Trim() && x.Surname.Trim() == entityT.Surname.Trim());
                if ((model.Id != Guid.Empty))
                {
                    
                    entity = await (model.Id != Guid.Empty ? _author.UpdateAsync(entity) : _author.AddAsync(entity));


                    if (model.Id != Guid.Empty && model.IsActive == false)
                    {

                        List<Book> entityList = await _book.GetListAsync(x => x.AuthorId == model.Id);

                        foreach (var item2 in entityList)
                        {
                            item2.IsActive = false;
                            _book.Update(item2);

                        }
                    }

                    authorResponseModel.Value = _mapper.Map<AuthorModel>(entity);
                    authorResponseModel.IsSuccess = true;
                }
                else if (model.Id == Guid.Empty && entityT == null)
                {
                    entity = await (model.Id != Guid.Empty ? _author.UpdateAsync(entity) : _author.AddAsync(entity));
                    authorResponseModel.Value = _mapper.Map<AuthorModel>(entity);
                    authorResponseModel.IsSuccess = true;
                }
             
                else
                {
                    authorResponseModel.IsSuccess = false;
                    authorResponseModel.Message = "Aynı Isimli Yazar Mevcut";
                    authorResponseModel.Value = model;
                }
            }
            catch (Exception e)
            {
                authorResponseModel.Message = "Bir Hata Oluştu";
                authorResponseModel.IsSuccess = false;
            }

            return authorResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public Response<AuthorModel> GetOne(Guid id)
        {
            Response<AuthorModel> authorResponse = new Response<AuthorModel>();
            Author entityList = _author.GetT(x => x.Id == id);
            authorResponse.Value = _mapper.Map<AuthorModel>(entityList);

            return authorResponse;
        }

        [HttpGet]
        [Route("Alphabetically")]
        public List<AuthorAlphabeticallyModel> AlphabeticalList()
        {
            List<AuthorAlphabeticallyModel> responseModel = new List<AuthorAlphabeticallyModel>();
            List<AuthorBasicModel> alphabeticList = new List<AuthorBasicModel>();

            var list = _author.GetList(x=>x.IsActive==true).ToList();
            var groupedByLetter =
                from letter in Letters
                join service in list on letter equals service.Name[0] into grouped
                select new { Letter = letter, list = grouped };

            foreach (var entry in groupedByLetter)
            {
                alphabeticList = new List<AuthorBasicModel>();
                AuthorAlphabeticallyModel UiModel = new AuthorAlphabeticallyModel();
                UiModel.Character = entry.Letter.ToString();

                foreach (var service in entry.list)
                {
                    AuthorBasicModel model = new AuthorBasicModel();
                    model.Name = service.Name;
                    model.SurName = service.Surname;
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


    }
}