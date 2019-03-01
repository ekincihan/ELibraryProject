using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Entities.Concrete;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            List<ContactModel> response = JsonConvert.DeserializeObject<List<ContactModel>>(UiRequestManager.Instance.Get("Contact", "GetMails"));

            return View(response);
        }

        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            if (Guid.Empty != id && id.HasValue)
            {
                Response<ContactModel> responseSaving = JsonConvert.DeserializeObject<Response<ContactModel>>(UiRequestManager.Instance.Get("Contact", "GetOne", id));
                responseSaving.Value = responseSaving.Value;
                return View(responseSaving.Value);

            }

            return View();

        }

        [HttpPost]
        public ActionResult Save(ContactModel model)
        {
            Response<ContactModel> responseSaving = JsonConvert.DeserializeObject<Response<ContactModel>>(UiRequestManager.Instance.Post("Contact", "Save", JsonConvert.SerializeObject(model)));

            return RedirectToAction("Index");
        }



        [HttpPost]
        public JsonResult Delete(ContactModel model)
        {
            Response<ContactModel> responseSaving = new Response<ContactModel>();
            UiRequestManager.Instance.Post("Contact", "Delete", JsonConvert.SerializeObject(model));

            return Json(responseSaving.IsSuccess=true);
        }
    }
}