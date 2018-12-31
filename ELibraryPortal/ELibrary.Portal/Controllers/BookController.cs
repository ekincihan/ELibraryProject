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
    public class BookController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            BookPageModel bookPageModel = new BookPageModel();
            Response<List<BookModel>> responsebooks = JsonConvert.DeserializeObject<Response<List<BookModel>>>(UiRequestManager.Instance.Get("Book", "List"));
            bookPageModel.BookList = responsebooks.Value;

            Response<List<AuthorModel>> responseauthor = JsonConvert.DeserializeObject<Response<List<AuthorModel>>>(UiRequestManager.Instance.Get("Author", "List"));

            bookPageModel.AuthorList = responseauthor.Value;

            Response<List<PublisherModel>> responsepublisher = JsonConvert.DeserializeObject<Response<List<PublisherModel>>>(UiRequestManager.Instance.Get("Publisher", "List"));

            bookPageModel.PubLisherList = responsepublisher.Value;
            return View(bookPageModel);
        }

        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            BookPageModel bookPageModel = new BookPageModel();

            Response<List<BookModel>> responseBooks = JsonConvert.DeserializeObject<Response<List<BookModel>>>(UiRequestManager.Instance.Get("Book", "List"));
            bookPageModel.BookList = responseBooks.Value;

            Response<List<AuthorModel>> responseAuthor = JsonConvert.DeserializeObject<Response<List<AuthorModel>>>(UiRequestManager.Instance.Get("Author", "List"));
            bookPageModel.AuthorList = responseAuthor.Value;

            Response<List<PublisherModel>> responsePublisher = JsonConvert.DeserializeObject<Response<List<PublisherModel>>>(UiRequestManager.Instance.Get("Publisher", "List"));
            bookPageModel.PubLisherList = responsePublisher.Value;

            if (Guid.Empty !=  id && id.HasValue)
            {
                Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Get("Book", "GetOne", id));
                bookPageModel.bookModel = responseSaving.Value;
            }
            
            return View(bookPageModel);
        }

        [HttpPost]
        public JsonResult Save(BookPageModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model.bookModel)));

            return Json(responseSaving);

        }
        [HttpGet]
        public ActionResult SaveTest()
        {

            return View();

        }

        [HttpPost]
        public JsonResult Delete(BookModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
    }
}
