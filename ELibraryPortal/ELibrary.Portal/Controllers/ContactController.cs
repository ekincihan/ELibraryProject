using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            StatusCodeResult responseSaving = JsonConvert.DeserializeObject<StatusCodeResult>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(id)));

            return Json(responseSaving.StatusCode);
        }
    }
}