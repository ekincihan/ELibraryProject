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
    public class AppTypeController : Controller
    {
        public ActionResult Index()
        {
            var types = JsonConvert.DeserializeObject<Response<List<TypeModel>>>(UiRequestManager.Instance.Get("Type", "List"));

            return View(types);
        }

        public ActionResult Save(Guid? id)
        {
            TypeModel model = new TypeModel();

            if (Guid.Empty != id && id.HasValue)
            {
                Response<TypeModel> responseSaving = JsonConvert.DeserializeObject<Response<TypeModel>>(UiRequestManager.Instance.Get("Type", "GetOne", id));
                model = responseSaving.Value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(TypeModel model)
        {
            Response<TypeModel> responseSaving = JsonConvert.DeserializeObject<Response<TypeModel>>(UiRequestManager.Instance.Post("Type", "Save", JsonConvert.SerializeObject(model)));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(TypeModel model)
        {
            Response<TypeModel> responseSaving = JsonConvert.DeserializeObject<Response<TypeModel>>(UiRequestManager.Instance.Post("Type", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }

    }
}