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
    public class PublisherController : Controller
    {
        public ActionResult Index()
        {
            var publishers = JsonConvert.DeserializeObject<Response<List<PublisherModel>>>(UiRequestManager.Instance.Get("Publisher", "List"));

            return View(publishers);
        }

        public ActionResult Save(Guid? id)
        {
            PublisherModel model = new PublisherModel();

            if (Guid.Empty != id && id.HasValue)
            {
                Response<PublisherModel> responseSaving = JsonConvert.DeserializeObject<Response<PublisherModel>>(UiRequestManager.Instance.Get("Publisher", "GetOne", id));
                model = responseSaving.Value;
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Save(PublisherModel model)
        {
            Response<PublisherModel> responseSaving = JsonConvert.DeserializeObject<Response<PublisherModel>>(UiRequestManager.Instance.Post("Publisher", "Save", JsonConvert.SerializeObject(model)));

            return Json(responseSaving);
        }

        [HttpPost]
        public JsonResult Delete(PublisherModel model)
        {
            Response<PublisherModel> responseSaving = JsonConvert.DeserializeObject<Response<PublisherModel>>(UiRequestManager.Instance.Post("Publisher", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
    }
}