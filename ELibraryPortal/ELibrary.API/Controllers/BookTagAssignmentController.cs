using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/BookTagAssignment")]
    [Produces("application/json")]
    public class BookTagAssignmentController : APIControllerBase
    {
        private readonly IBookTagAssignment _bookTagAssignment;
        private readonly IMapper _mapper;
        public BookTagAssignmentController(IBookTagAssignment bookTagAssignment, IMapper mapper)
        {
            _bookTagAssignment = bookTagAssignment;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("List/{bookId}")]
        public async Task<Response<List<BookTagAssignment>>> GetAsync(Guid bookId)
        {
            Response<List<BookTagAssignment>> bookResponse = new Response<List<BookTagAssignment>>();
            List<BookTagAssignment> entityList = await _bookTagAssignment.GetListAsync(x => x.IsActive == true && x.BookId == bookId);
            bookResponse.Value = _mapper.Map<List<BookTagAssignment>>(entityList.OrderByDescending(f => f.CreatedDate));
            return bookResponse;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<Response<bool>> Post([FromBody]List<BookTagAssignment> modelList)
        {
            Response<bool> bookTagResponseModel = new Response<bool>();
            Response<List<BookTagAssignment>> bookTagAssignmentList = await GetAsync(modelList.FirstOrDefault().BookId);

            var tags = bookTagAssignmentList.Value.Select(f => f.TagId).ToList();
            try
            {
                foreach (BookTagAssignment model in modelList)
                {
                    if (tags.IndexOf(model.TagId) < 0)
                    {
                        BookTagAssignment entity = _mapper.Map<BookTagAssignment>(model);
                        entity = await (model.Id != Guid.Empty ? _bookTagAssignment.UpdateAsync(entity) : _bookTagAssignment.AddAsync(entity));
                        bookTagResponseModel.IsSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                bookTagResponseModel.Exception = e;
                bookTagResponseModel.IsSuccess = false;
            }

            return bookTagResponseModel;
        }
    }
}
