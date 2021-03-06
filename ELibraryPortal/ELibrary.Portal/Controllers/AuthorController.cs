﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Custom;
using ELibrary.Portal.Helpers;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class AuthorController :  Controller
    {
        public IActionResult Index()
        {
            var authors = JsonConvert.DeserializeObject<Response<List<AuthorModel>>>(UiRequestManager.Instance.Get("Author", "List"));
            return View(authors);
        }
        
        public IActionResult Save(Guid? id)
        {
            AuthorModel model = new AuthorModel();

            if (Guid.Empty != id && id.HasValue)
            {
                Response<AuthorModel> responseSaving = JsonConvert.DeserializeObject<Response<AuthorModel>>(UiRequestManager.Instance.Get("Author", "GetOne", id));
                model = responseSaving.Value;
            }

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Save(AuthorModel model)
        {
            Response<AuthorModel> responseSaving = JsonConvert.DeserializeObject<Response<AuthorModel>>(UiRequestManager.Instance.Post("Author", "Save", JsonConvert.SerializeObject(model)));

            if (model.FormFile != null)
            {
                AppFileFilterModel appFileFilterModel = new AppFileFilterModel
                {
                    AppFileModuleId = responseSaving.Value.Id,
                    ModuleType = API.Models.Enum.Enum.Module.AuthorThumbnail,
                    File = model.FormFile
                };

                await AppFileUploadHelper.Instance.UploadFile(appFileFilterModel);
            }
            return Json(responseSaving);
        }

        [HttpPost]
        public JsonResult Delete(AuthorModel model)
        {
            Response<AuthorModel> responseSaving = JsonConvert.DeserializeObject<Response<AuthorModel>>(UiRequestManager.Instance.Post("Author", "Save", JsonConvert.SerializeObject(model)));

            return Json(new ResultJson { Message = responseSaving.Message, Success = responseSaving.IsSuccess });
        }


    }
}