using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Manager;
using ELibrary.Portal.Models;
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
            CategoryPageModel categoryPageModel = new CategoryPageModel();

            Response<List<CategoryModel>> responsecategory = JsonConvert.DeserializeObject<Response<List<CategoryModel>>>(UiRequestManager.Instance.Get("Category", "List"));
            categoryPageModel.CategoryList = responsecategory.Value;

            Response<List<TypeModel>> rest = JsonConvert.DeserializeObject<Response<List<TypeModel>>>(UiRequestManager.Instance.Get("Type", "List"));

            categoryPageModel.TypeList = rest.Value;

           
            return View(categoryPageModel);

        }
        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            CategoryPageModel categoryPageModel = new CategoryPageModel();

            Response<List<CategoryModel>> responsecategory = JsonConvert.DeserializeObject<Response<List<CategoryModel>>>(UiRequestManager.Instance.Get("Category", "List"));
            categoryPageModel.CategoryList = responsecategory.Value;

            Response<List<TypeModel>> rest = JsonConvert.DeserializeObject<Response<List<TypeModel>>>(UiRequestManager.Instance.Get("Type", "List"));

            categoryPageModel.TypeList = rest.Value;

            if (Guid.Empty != id && id.HasValue)
            {
                Response<CategoryModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryModel>>(UiRequestManager.Instance.Get("Category", "GetOne",id));
                categoryPageModel.categoryModel = responseSaving.Value;
            }

            return View(categoryPageModel);
        }

        [HttpPost]
        public JsonResult Save(CategoryPageModel model)
        {
            Response<CategoryModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryModel>>(UiRequestManager.Instance.Post("Category", "Save", JsonConvert.SerializeObject(model.categoryModel)));

            return Json(responseSaving);
        }

        [HttpPost]
        public JsonResult Delete(CategoryModel model)
        {
            Response<CategoryModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryModel>>(UiRequestManager.Instance.Post("Category", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }

    }
}
