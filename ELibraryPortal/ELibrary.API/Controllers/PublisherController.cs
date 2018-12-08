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
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : APIControllerBase
    {
        private readonly IPublisher _publisher;
        private IMapper _mapper;

        public PublisherController(IPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        public async Task<Response<PublisherModel>> Post([FromBody]PublisherModel model)
        {
            Response<PublisherModel> publisherResponseModel = new Response<PublisherModel>();
            try
            {
                Publisher entity = _mapper.Map<Publisher>(model);
                entity= await _publisher.AddAsync(entity);
                publisherResponseModel.Value = _mapper.Map<PublisherModel>(entity);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }
    }
}