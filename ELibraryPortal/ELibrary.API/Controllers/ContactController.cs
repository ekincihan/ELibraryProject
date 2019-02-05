using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
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
    public class ContactController : ControllerBase
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

        [HttpGet]
        [Route("Delete")]
        public ActionResult GetMails(Guid id)
        {
            _contact.Delete(_contact.GetT(x => x.Id == id));

            return StatusCode(200);
        }


    }
}