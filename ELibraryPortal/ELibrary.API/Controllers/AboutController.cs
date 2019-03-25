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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/About")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class AboutController : APIControllerBase
    {
        private readonly IAbout _about;
        private readonly IMapper _mapper;


        public AboutController(IAbout about, IMapper mapper)
        {
            _about = about;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("List")]
        public async Task<Response<List<AboutModel>>> AsyncGet()
        {
            Response<List<AboutModel>> aboutResponse = new Response<List<AboutModel>>();
            List<About> entityList = await _about.GetListAsync();
            aboutResponse.Value = _mapper.Map<List<AboutModel>>(entityList);
            return aboutResponse;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<Response<AboutModel>> Post([FromBody]AboutModel model)
        {
            Response<AboutModel> aboutesponseModel = new Response<AboutModel>();

            try
            {
                About entity = _mapper.Map<About>(model);
                entity.IsActive = true;
                entity = await (model.Id != Guid.Empty ? _about.UpdateAsync(entity) : _about.AddAsync(entity));
                aboutesponseModel.Value = _mapper.Map<AboutModel>(entity);
                aboutesponseModel.IsSuccess = true;

            }
            catch (Exception e)
            {

                aboutesponseModel.Exception = e;
                aboutesponseModel.IsSuccess = false;
            }

            return aboutesponseModel;
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public async Task<Response<AboutModel>> GetOne(Guid id)
        {
            Response<AboutModel> aboutResponse = new Response<AboutModel>();
            About entityList = await _about.GetTAsync(x => x.Id == id);
            aboutResponse.Value = _mapper.Map<AboutModel>(entityList);

            return aboutResponse;
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(ContactModel model)
        {
            _about.Delete(_about.GetT(x => x.Id == model.Id));

            return StatusCode(200);
        }

        [HttpGet]
        [Route("GetAbout")]
        public AboutModel GetAbout()
        {
            AboutModel aboutResponse = new AboutModel();
            List<About> entityList = _about.GetList();
            List<AboutModel> models = _mapper.Map<List<AboutModel>>(entityList);
            aboutResponse = models.Take(1).First();
            return aboutResponse;
        }

    }
}
