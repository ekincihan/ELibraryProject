using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using Microsoft.AspNetCore.Mvc;
using ELibrary.Entities.Concrete;

namespace ELibrary.API.Controllers
{
    [Route("api/Type")]
    [ApiController]
    public class TypeController : APIControllerBase
    {
        private readonly IType _type;
        private readonly IMapper _mapper;

        public TypeController(IType type,IMapper mapper)
        {
            _type = type;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("List")]
        public Response<List<TypeModel>> Get()
        {
            Response<List<TypeModel>> typeResponse = new Response<List<TypeModel>>();
            List<AppType> entityList = _type.GetList(x => x.IsActive == true);
            typeResponse.Value = _mapper.Map<List<TypeModel>>(entityList);

            return typeResponse;
        }


        [HttpPost]
        [Route("Save")]
        public async Task<Response<TypeModel>> Post([FromBody]TypeModel model)
        {
            Response<TypeModel> typeResponseModel = new Response<TypeModel>();
            try
            {
                AppType entity = _mapper.Map<AppType>(model);
                entity = await (model.Id != Guid.Empty ? _type.UpdateAsync(entity) : _type.AddAsync(entity));
                typeResponseModel.Value = _mapper.Map<TypeModel>(entity);
                typeResponseModel.IsSuccess = true;
            }
            catch (Exception e)
            {
                typeResponseModel.Exception = e;
                typeResponseModel.IsSuccess = false;
            }

            return typeResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public Response<TypeModel> GetOne(Guid id)
        {
            Response<TypeModel> typeResponse = new Response<TypeModel>();
            AppType entityList = _type.GetT(x => x.Id == id);
            typeResponse.Value = _mapper.Map<TypeModel>(entityList);

            return typeResponse;
        }


    }
}