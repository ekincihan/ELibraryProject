using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var categories = JsonConvert.DeserializeObject<Response<List<CategoryModel>>>(UiRequestManager.Instance.Get("Category", "List"));

            return View(categories);
        }
        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            CategoryModel model = new CategoryModel();

            if (Guid.Empty != id && id.HasValue)
            {
                Response<CategoryModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryModel>>(UiRequestManager.Instance.Get("Category", "GetOne"));
                model = responseSaving.Value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(CategoryModel model)
        {
            Response<CategoryModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryModel>>(UiRequestManager.Instance.Get("Category", "Save", JsonConvert.SerializeObject(model)));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(CategoryModel model)
        {
            Response<CategoryModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryModel>>(UiRequestManager.Instance.Get("Category", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }

    }
}
