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
    public class TagController : Controller
    {
        public ActionResult Index()
        {
            var tags = JsonConvert.DeserializeObject<Response<List<TagModel>>>(UiRequestManager.Instance.Get("Tag", "List"));

            return View(tags);
        }

        public ActionResult Save(Guid? id)
        {
            TagModel model = new TagModel();

            if (Guid.Empty != id && id.HasValue)
            {
                Response<TagModel> responseSaving = JsonConvert.DeserializeObject<Response<TagModel>>(UiRequestManager.Instance.Get("Tag", "GetOne", id));
                model = responseSaving.Value;
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Save(TagModel model)
        {
            Response<TagModel> responseSaving = JsonConvert.DeserializeObject<Response<TagModel>>(UiRequestManager.Instance.Post("Tag", "Save", JsonConvert.SerializeObject(model)));

            return Json(responseSaving);
        }

        [HttpPost]
        public JsonResult Delete(TagModel model)
        {
            Response<TagModel> responseSaving = JsonConvert.DeserializeObject<Response<TagModel>>(UiRequestManager.Instance.Post("Tag", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
    }
}