using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ELibrary.Portal.Controllers
{
    public class AboutController : UIControllerBase
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<AboutModel> models = new List<AboutModel>();
            Response<List<AboutModel>> responsebooks = JsonConvert.DeserializeObject<Response<List<AboutModel>>>(UiRequestManager.Instance.Get("About", "List"));
            models = responsebooks.Value;
            return View(models);
        }

        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            if (Guid.Empty != id && id.HasValue)
            {
                Response<AboutModel> responseSaving = JsonConvert.DeserializeObject<Response<AboutModel>>(UiRequestManager.Instance.Get("About", "GetOne", id));
                responseSaving.Value = responseSaving.Value;
                return View(responseSaving.Value);

            }

            return View();

        }

        [HttpPost]
        public ActionResult Save(AboutModel model)
        {
            Response<AboutModel> responseSaving = JsonConvert.DeserializeObject<Response<AboutModel>>(UiRequestManager.Instance.Post("About", "Save", JsonConvert.SerializeObject(model)));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(AboutModel model)
        {
            Response<ContactModel> responseSaving = new Response<ContactModel>();
            UiRequestManager.Instance.Post("About", "Delete", JsonConvert.SerializeObject(model));

            return Json(responseSaving.IsSuccess = true);
        }
    }
}
