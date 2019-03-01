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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/Contact")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class ContactController : APIControllerBase
    {
        private readonly IContact _contact;
        private readonly IMapper _mapper;
        public ContactController(IContact contact, IMapper mapper)
        {
            _contact = contact;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("SendMail")]
        public ActionResult SendMail([FromBody] ContactModel model)
        {
            Contact entity = new Contact();
            entity.NameSurname = model.NameSurname;
            entity.Email = model.Email;
            entity.Message = model.Message;
            _contact.Add(entity);

            return StatusCode(200);
        }

        [HttpGet]
        [Route("GetMails")]
        public List<ContactModel> GetMails()
        {
            List<Contact> entities = _contact.GetList();
            List<ContactModel> models = _mapper.Map<List<ContactModel>>(entities);

            return models;
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(ContactModel model)
        {
            _contact.Delete(_contact.GetT(x => x.Id == model.Id));

            return StatusCode(200);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<Response<ContactModel>> Post([FromBody]ContactModel model)
        {
            Response<ContactModel> contactresponsemodel = new Response<ContactModel>();
            try
            {
                Contact entity = _mapper.Map<Contact>(model);
                entity.Type = 3;
                entity = await (model.Id != Guid.Empty ? _contact.UpdateAsync(entity) : _contact.AddAsync(entity));
                contactresponsemodel.Value = _mapper.Map<ContactModel>(entity);
                contactresponsemodel.IsSuccess = true;

            }
            catch (Exception e)
            {

                contactresponsemodel.Exception = e;
                contactresponsemodel.IsSuccess = false;
            }

            return contactresponsemodel;
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<Response<ContactModel>> GetOne()
        {
            Response<ContactModel> contactResponse = new Response<ContactModel>();
            Contact entityList = await _contact.GetTAsync(x => x.Type == 3);
            contactResponse.Value = _mapper.Map<ContactModel>(entityList);

            return contactResponse;
        }
    }
}