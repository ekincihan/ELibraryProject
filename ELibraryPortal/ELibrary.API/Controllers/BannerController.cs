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
    [Route("api/Banner")]
    [ApiController]
    public class BannerController : APIControllerBase
    {
        private readonly IBanner _banner;
        private readonly IMapper _mapper;

        public BannerController(IBanner banner, IMapper mapper)
        {
            _banner = banner;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("List")]
        public Response<List<BannerModel>> Get()
        {
            Response<List<BannerModel>> bannerResponse = new Response<List<BannerModel>>();
            List<Banner> entityList = _banner.GetList();
            bannerResponse.Value = _mapper.Map<List<BannerModel>>(entityList);

            return bannerResponse;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<Response<BannerModel>> Post([FromBody]BannerModel model)
        {
            Response<BannerModel> bannerResponseModel = new Response<BannerModel>();
            if (model.IsActive)
            {
                Response<BannerModel> bannerResponse = new Response<BannerModel>();
                Banner entityList = _banner.GetT(x => x.IsActive == true);
                entityList.IsActive = false;
                entityList = await _banner.UpdateAsync(entityList);
                //bannerResponse.Value = _mapper.Map<BannerModel>(entityList);
            }
            try
            {
                Banner entity = _mapper.Map<Banner>(model);
                entity = await (model.Id != Guid.Empty ? _banner.UpdateAsync(entity) : _banner.AddAsync(entity));
                bannerResponseModel.Value = _mapper.Map<BannerModel>(entity);
                bannerResponseModel.IsSuccess = true;
            }
            catch (Exception e)
            {
                bannerResponseModel.Exception = e;
                bannerResponseModel.IsSuccess = false;
            }

            return bannerResponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public Response<BannerModel> GetOne(Guid id)
        {
            Response<BannerModel> bannerResponse = new Response<BannerModel>();
            Banner entityList = _banner.GetT(x => x.Id == id);
            bannerResponse.Value = _mapper.Map<BannerModel>(entityList);

            return bannerResponse;
        }

        [HttpGet]
        [Route("Current")]
        public Response<BannerModel> Current()
        {
            Response<BannerModel> bannerResponse = new Response<BannerModel>();
            Banner entityList = _banner.GetT(x => x.IsActive == true);
            bannerResponse.Value = _mapper.Map<BannerModel>(entityList);

            return bannerResponse;
        }
    }
}
