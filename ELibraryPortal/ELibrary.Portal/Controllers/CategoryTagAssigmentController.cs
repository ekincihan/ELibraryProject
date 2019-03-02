using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Manager;
using ELibrary.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class CategoryTagAssigmentController : UIControllerBase
    {
        public IActionResult Index()
        {
            Response<List<CategoryTagAssigmentModel>> responseTags = JsonConvert.DeserializeObject<Response<List<CategoryTagAssigmentModel>>>(UiRequestManager.Instance.Get("CategoryTagAssignment", "List"));
            return View();
        }

        public IActionResult Save()
        {
            CategoryTagAssigmentPageModel pageModel = new CategoryTagAssigmentPageModel();

            Response<List<BookModel>> responsebooks = JsonConvert.DeserializeObject<Response<List<BookModel>>>(UiRequestManager.Instance.Get("Book", "List"));
            pageModel.BooklList = responsebooks.Value;

            Response<List<TagModel>> responseTags = JsonConvert.DeserializeObject<Response<List<TagModel>>>(UiRequestManager.Instance.Get("Tag", "List"));
            pageModel.TagList = responseTags.Value;

            Response<List<CategoryModel>> responsecategory = JsonConvert.DeserializeObject<Response<List<CategoryModel>>>(UiRequestManager.Instance.Get("Category", "List"));
            pageModel.CategoryList = responsecategory.Value;

            return View(pageModel);

        }
        [HttpPost]
        public JsonResult Save(CategoryTagAssigmentModel model)
        {
            Response<CategoryTagAssigmentModel> responseSaving = JsonConvert.DeserializeObject<Response<CategoryTagAssigmentModel>>(UiRequestManager.Instance.Post("CategoryTagAssignment", "Save", JsonConvert.SerializeObject(model)));

            return Json(responseSaving);
        }
    }
}