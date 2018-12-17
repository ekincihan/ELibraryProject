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
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var books = JsonConvert.DeserializeObject<Response<List<BookModel>>>(UiRequestManager.Instance.Get("Book", "List"));

            return View(books);
        }

        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            BookModel model = new BookModel();

            if (Guid.Empty !=  id && id.HasValue)
            {
                Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Get("Book", "GetOne"));
                model = responseSaving.Value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(BookModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model)));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(BookModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
    }
}
