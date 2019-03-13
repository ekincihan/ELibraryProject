
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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using ELibrary.Entities.Concrete;

namespace ELibrary.Portal.Controllers
{
    public class BookController : UIControllerBase
    {
        private IMemoryCache _cache;

        public BookController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;

        }

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
            if (Guid.Empty != id && id.HasValue)
            {
                Response<BookModel> responseBooks = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Get("Book", "GetOne", id));
                bookPageModel.BookModel= responseBooks.Value;
            }

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
                bookPageModel.BookModel = responseSaving.Value;

                Response<List<CategoryTagAssigmentModel>> categoryTagAssignementModel = JsonConvert.DeserializeObject<Response<List<CategoryTagAssigmentModel>>>(UiRequestManager.Instance.Get("CategoryTagAssignment", "List"));
                bookPageModel.BookModel.CategoryId = categoryTagAssignementModel.Value.Count > 0 ? categoryTagAssignementModel.Value.FirstOrDefault(x=>x.BookId == id).CategoryId : Guid.Empty;

                Response<List<BookTagAssignmentModel>> bookTagAssignementModel = JsonConvert.DeserializeObject<Response<List<BookTagAssignmentModel>>>(UiRequestManager.Instance.Get("BookTagAssignment", "List", id));
                bookPageModel.Tags = bookTagAssignementModel.Value.Select(f => f.TagId.ToString()).ToArray();
            }

            return View(bookPageModel);
        }

        [HttpPost]
        public async Task<JsonResult> Save(BookPageModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model.BookModel)));

            if (responseSaving.Value==null)
            {
                return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
            }

            AppFileFilterModel appFileFilterModel = new AppFileFilterModel
            {
                AppFileModuleId = responseSaving.Value.Id,
                ModuleType = API.Models.Enum.Enum.Module.BookThumbnail,
                File = model.Thumbnail
            };


            var thumbNail = await AppFileUploadHelper.Instance.UploadFile(appFileFilterModel);

            appFileFilterModel.File = model.Publication;
            appFileFilterModel.ModuleType = API.Models.Enum.Enum.Module.Publication;

            var book = await AppFileUploadHelper.Instance.UploadFile(appFileFilterModel);

          


            if ( model.BookModel.Id != Guid.Empty && (book != null || thumbNail != null))
            {
                
                JsonConvert.DeserializeObject<Response<BookModel>>(UiRequestManager.Instance.Post("Book", "Save", JsonConvert.SerializeObject(model.BookModel)));
            }

            model.BookModel.CategoryTagAssigment.BookId = responseSaving.Value.Id;
            model.BookModel.CategoryTagAssigment.BookName = model.BookModel.BookName;
            model.BookModel.CategoryTagAssigment.BookSummary = model.BookModel.BookSummary;
            model.BookModel.CategoryTagAssigment.SignUrl = thumbNail.Value != null ? thumbNail.Value.SignUrl : responseSaving.Value.Thumbnail.SignUrl;
            model.BookModel.CategoryTagAssigment.AuthorId = model.BookModel.AuthorId;
            model.BookModel.CategoryTagAssigment.AuthorSurname = model.BookModel.Author.Surname;
            model.BookModel.CategoryTagAssigment.PublisherId = model.BookModel.PublisherId;
            model.BookModel.CategoryTagAssigment.BookSummary = model.BookModel.BookSummary;
            model.BookModel.CategoryTagAssigment.CategoryId = model.BookModel.CategoryId;
            model.BookModel.CategoryTagAssigment.IsActive = model.BookModel.IsActive;

            JsonConvert.DeserializeObject<Response<CategoryTagAssigmentModel>>(UiRequestManager.Instance.Post("CategoryTagAssignment", "Save", JsonConvert.SerializeObject(model.BookModel.CategoryTagAssigment)));
            if (model.Tags != null && model.Tags.Count() > 0)
            {
                List<BookTagAssignmentModel> modelList = new List<BookTagAssignmentModel>();
                foreach (var item in model.Tags)
                {
                    modelList.Add(new BookTagAssignmentModel
                    {
                        BookId = responseSaving.Value.Id,
                        TagId = Guid.Parse(item)
                    });

                }
                JsonConvert.DeserializeObject<Response<bool>>(UiRequestManager.Instance.Post("BookTagAssignment", "Save", JsonConvert.SerializeObject(modelList)));
            }
            return Json(new ResultJson { Message=responseSaving.Message,Success=responseSaving.IsSuccess});
        }

        [HttpPost]
        public async Task<JsonResult> Delete(BookModel model)
        {
            Response<BookModel> responseSaving = JsonConvert.DeserializeObject<Response<BookModel>>(await UiRequestManager.Instance.PostAsync("Book", "Save", JsonConvert.SerializeObject(model)));

            CategoryTagAssigmentModel categoryTagAssigmentModel = new CategoryTagAssigmentModel();
            categoryTagAssigmentModel.IsActive = false;
            categoryTagAssigmentModel.BookId = model.Id;
            JsonConvert.DeserializeObject<Response<CategoryTagAssigmentModel>>(UiRequestManager.Instance.Post("CategoryTagAssignment", "Save", JsonConvert.SerializeObject(categoryTagAssigmentModel)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
        [HttpPost]
        public async Task<JsonResult> RemoveFile(AppFileModel model)
        {
            Response<AppFileModel> responseSaving = JsonConvert.DeserializeObject<Response<AppFileModel>>(await UiRequestManager.Instance.PostAsync("AppFile", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }

        [HttpPost]
        public void SetSessionValues(SessionModel model)
        {
            _cache.Set("BookName", model.BookName,TimeSpan.FromMinutes(4));
            _cache.Set("BookSummary", model.BookSummary, TimeSpan.FromMinutes(4));
            _cache.Set("NumberPages", model.NumberPages, TimeSpan.FromMinutes(4));
            _cache.Set("PublisherVal", model.PublisherVal != null ? model.PublisherVal : "", TimeSpan.FromMinutes(4));
            _cache.Set("PublisherText", model.PublisherText, TimeSpan.FromMinutes(4));
            _cache.Set("AuthorVal", model.AuthorVal != null ? model.AuthorVal : "", TimeSpan.FromMinutes(4));
            _cache.Set("AuthorText", model.AuthorText, TimeSpan.FromMinutes(4));
            _cache.Set("EtiketHtml", model.EtiketHtml, TimeSpan.FromMinutes(4));
        }

        public JsonResult GetSession()
        {

            SessionModel model = new SessionModel();
            model.BookName = _cache.Get<string>("BookName");
            model.BookSummary = _cache.Get<string>("BookSummary");
            model.NumberPages = _cache.Get<int>("NumberPages");
            model.PublisherVal = _cache.Get<string>("PublisherVal");
            model.PublisherText = _cache.Get<string>("PublisherText");
            model.AuthorVal = _cache.Get<string>("AuthorVal");
            model.AuthorText = _cache.Get<string>("AuthorText");
            model.EtiketHtml = _cache.Get<string>("EtiketHtml");

            if (_cache.Get<string>("BookName") != null || _cache.Get<string>("BookSummary") != null || _cache.Get<int>("NumberPages") != 0 ||
                _cache.Get<string>("PublisherVal") != null || _cache.Get<string>("AuthorVal") != null)
            {
                model.IsSessionEmpty= true;
            }
            return Json(model);
        }

        public void DeleteCache()
        {
            _cache.Remove("BookName");
            _cache.Remove("BookSummary");
            _cache.Remove("NumberPages");
            _cache.Remove("PublisherVal");
            _cache.Remove("PublisherText");
            _cache.Remove("AuthorVal");
            _cache.Remove("AuthorText");
        }
    }
}
