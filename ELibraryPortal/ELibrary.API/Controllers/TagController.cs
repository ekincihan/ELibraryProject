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
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.API.Controllers
{
    [Route("api/Tag")]
    [ApiController]
    public class TagController : APIControllerBase
    {
        private readonly ITag _tag;
        public IMapper _mapper;


        public TagController(ITag tag, IMapper mapper)
        {
            _tag = tag;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("List")]
        public async Task<Response<List<TagModel>>> AsyncGet()
        {
            Response<List<TagModel>> tagResponse = new Response<List<TagModel>>();
            List<Tag> entityList = await _tag.GetListAsync(x => x.IsActive == true);
            tagResponse.Value = _mapper.Map<List<TagModel>>(entityList);
            return tagResponse;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<Response<TagModel>> Post([FromBody]TagModel model)
        {
            Response<TagModel> tagResponseModel = new Response<TagModel>();

            try
            {
                Tag entity = _mapper.Map<Tag>(model);
                entity = await (model.Id != Guid.Empty ? _tag.UpdateAsync(entity) : _tag.AddAsync(entity));
                tagResponseModel.Value = _mapper.Map<TagModel>(entity);
                tagResponseModel.IsSuccess = true;

            }
            catch (Exception e)
            {

                tagResponseModel.Exception = e;
                tagResponseModel.IsSuccess = false;
            }

            return tagResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public async Task<Response<TagModel>> GetOne(Guid id)
        {
            Response<TagModel> tagResponse = new Response<TagModel>();
            Tag entityList = await _tag.GetTAsync(x => x.Id == id);
            tagResponse.Value = _mapper.Map<TagModel>(entityList);

            return tagResponse;
        }
    }
}