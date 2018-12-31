﻿using System;
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
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;

        public PublisherController(IPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
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

        [HttpPost]
        [Route("Save")]
        public async Task<Response<PublisherModel>> Post([FromBody]PublisherModel model)
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


    }

}