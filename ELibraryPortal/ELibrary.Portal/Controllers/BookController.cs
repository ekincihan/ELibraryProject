
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Helpers;
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

            Response<List<TagModel>> responseTags = JsonConvert.DeserializeObject<Response<List<TagModel>>>(UiRequestManager.Instance.Get("Tag", "List"));
            bookPageModel.TagList = responseTags.Value;

            Response<List<CategoryModel>> responsecategory = JsonConvert.DeserializeObject<Response<List<CategoryModel>>>(UiRequestManager.Instance.Get("Category", "List"));
            bookPageModel.CategoryList = responsecategory.Value;

            if (Guid.Empty != id && id.HasValue)
            {
                Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Get("Book", "GetOne", id));
                bookPageModel.bookModel = responseSaving.Value;
            }

            return View(bookPageModel);
        }

        [HttpPost]
        public async Task<JsonResult> Save(BookPageModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model.bookModel)));

            AppFileFilterModel appFileFilterModel = new AppFileFilterModel
            {
                AppFileModuleId = responseSaving.Value.Id,
                ModuleType = API.Models.Enum.Enum.Module.BookThumbnail,
                File = model.Thumbnail
            };

            var thumbNail = await AppFileUploadHelper.Instance.UploadFile(appFileFilterModel);

            appFileFilterModel.File = model.Publication;
            appFileFilterModel.ModuleType = API.Models.Enum.Enum.Module.Publication;

            await AppFileUploadHelper.Instance.UploadFile(appFileFilterModel);

            model.bookModel.CategoryTagAssigment.BookId = responseSaving.Value.Id;
            model.bookModel.CategoryTagAssigment.BookName = model.bookModel.BookName;
            model.bookModel.CategoryTagAssigment.BookSummary = model.bookModel.BookSummary;
            model.bookModel.CategoryTagAssigment.SignUrl = thumbNail.Value.SignUrl;
            model.bookModel.CategoryTagAssigment.AuthorId = model.bookModel.AuthorId;
            model.bookModel.CategoryTagAssigment.AuthorSurname = model.bookModel.Author.Surname;
            model.bookModel.CategoryTagAssigment.PublisherId = model.bookModel.AuthorId;


            JsonConvert.DeserializeObject<Response<CategoryTagAssigmentModel>>(UiRequestManager.Instance.Post("CategoryTagAssignment", "Save", JsonConvert.SerializeObject(model.bookModel.CategoryTagAssigment)));

            return Json(responseSaving);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(BookModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(await UiRequestManager.Instance.PostAsync("Book", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
        [HttpPost]
        public async Task<JsonResult> RemoveFile(AppFileModel model)
        {
            Response<AppFileModel> responseSaving = JsonConvert.DeserializeObject<Response<AppFileModel>>(await UiRequestManager.Instance.PostAsync("AppFile", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
    }
}
