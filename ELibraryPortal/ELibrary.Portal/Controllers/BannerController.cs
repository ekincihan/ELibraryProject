using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Helpers;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class BannerController : UIControllerBase
    {
       
        public ActionResult Index()
        {
            var banner = JsonConvert.DeserializeObject<Response<List<BannerModel>>>(UiRequestManager.Instance.Get("Banner", "List"));
            return View(banner);
        }

        public ActionResult Save(Guid? id)
        {
            BannerModel model = new BannerModel();
            Response<BannerModel> responseSaving = new Response<BannerModel>();

            if (Guid.Empty != id && id.HasValue)
            {
                responseSaving = JsonConvert.DeserializeObject<Response<BannerModel>>(UiRequestManager.Instance.Get("Banner", "GetOne", id));
                model = responseSaving.Value;
            }
           
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Save(BannerModel model)
        {
            Response<BannerModel> responseSaving = JsonConvert.DeserializeObject<Response<BannerModel>>(UiRequestManager.Instance.Post("Banner", "Save", JsonConvert.SerializeObject(model)));

            if (responseSaving.Value.Id != Guid.Empty)
            {
                AppFileFilterModel appFileFilterModel = new AppFileFilterModel
                {
                    AppFileModuleId = responseSaving.Value.Id,
                    ModuleType = API.Models.Enum.Enum.Module.Banner,
                    File = model.FormFile
                };

                await AppFileUploadHelper.Instance.UploadFile(appFileFilterModel);
            }
            return Json(responseSaving);
        }

        [HttpPost]
        public JsonResult Delete(BannerModel model)
        {
            Response<BannerModel> responseSaving = JsonConvert.DeserializeObject<Response<BannerModel>>(UiRequestManager.Instance.Post("Banner", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }
    }
}
