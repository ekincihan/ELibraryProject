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
    [ApiController]
    [Route("api/Book")]
    [Produces("application/json")]
    public class BookController : APIControllerBase
    {
        private readonly IBooks _book;
        private readonly IMapper _mapper;

        public BookController(IBooks book, IMapper mapper)
        {
            _book = book;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("List")]
        public async Task<Response<List<BookModel>>> AsyncGet()
        {
            Response<List<BookModel>> bookResponse = new Response<List<BookModel>>();
            List<Book> entityList = await _book.GetListAsync(x => x.IsActive == true);
            bookResponse.Value = _mapper.Map<List<BookModel>>(entityList.OrderByDescending(f => f.CreatedDate));
            return bookResponse;
        }

        [HttpGet]
        [Route("LastAdded")]
        public async Task<Response<List<BookModel>>> LastAdded()
        {
            Response<List<BookModel>> bookResponse = new Response<List<BookModel>>();
            List<Book> entityList = await _book.GetListAsync(x => x.IsActive == true);
            bookResponse.Value = _mapper.Map<List<BookModel>>(entityList.OrderByDescending(f => f.CreatedDate)).Take(6).ToList();
            return bookResponse;
        }


        [HttpGet]
        [Route("MostReads")]
        public async Task<Response<List<BookModel>>> MostReads()
        {
            Response<List<BookModel>> bookResponse = new Response<List<BookModel>>();
            List<Book> entityList = await _book.GetListAsync(x => x.IsActive == true);
            bookResponse.Value = _mapper.Map<List<BookModel>>(entityList.OrderByDescending(f => f.ReadCount)).Take(6).ToList();
            return bookResponse;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<Response<BookModel>> Post([FromBody]BookModel model)
        {
            Response<BookModel> bookResponseModel = new Response<BookModel>();

            try
            {
                Book entity = _mapper.Map<Book>(model);
                entity = await (model.Id != Guid.Empty ? _book.UpdateAsync(entity) : _book.AddAsync(entity));
                bookResponseModel.Value = _mapper.Map<BookModel>(entity);
                bookResponseModel.IsSuccess = true;

            }
            catch (Exception e)
            {
                bookResponseModel.Exception = e;
                bookResponseModel.IsSuccess = false;

            }

            return bookResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public async Task<Response<BookModel>> GetOne(Guid id)
        {
            Response<BookModel> bookResponse = new Response<BookModel>();
            Book entityList = await _book.GetTAsync(x => x.Id == id && x.IsActive == true);
            bookResponse.Value = _mapper.Map<BookModel>(entityList);

            return bookResponse;
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<Response<BookModel>> BookDetail(Guid id)
        {
            Response<BookModel> bookResponse = new Response<BookModel>();
            Book entityList = await _book.GetTAsync(x => x.Id == id && x.IsActive == true);
            bookResponse.Value = _mapper.Map<BookModel>(entityList);

            return bookResponse;
        }

        [HttpPost]
        [Route("ReadBook")]
        public async Task<ActionResult> ReadBook([FromBody]Guid id)
        {
            try
            {
                Book entity = await _book.GetTAsync(x => x.Id == id);
                entity.ReadCount += 1;
                var result = _book.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                return StatusCode(403);
            }

            return StatusCode(200);
        }

    }
}
