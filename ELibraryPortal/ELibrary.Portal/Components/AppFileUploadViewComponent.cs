using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Helpers;
using ELibrary.Portal.Manager;
using ELibrary.Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Components
{
    public class AppFileUploadViewComponent : ViewComponent 
    {
        public AppFileUploadViewComponent()
        {
        }

        public IViewComponentResult  Invoke(AppFileFilterModel model) 
        {
            if (HttpContext.Request.Method == "POST")
            {
                return Post(model);
            }

            return Get(model);
        }
        private IViewComponentResult Get(AppFileFilterModel model)
        {
            return View(model);
        }

        private IViewComponentResult Post(AppFileFilterModel model)
        {
            return View(model);
        }
        public async Task<bool> UploadFile(AppFileFilterModel file)
        {
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.File.GetFilename());
            AppFileModel model = new AppFileModel();

            using (var stream = new FileStream(path, FileMode.Create))
            {
                model = new AppFileModel
                {
                    FilePath = path,
                    ModuleId = file.AppFileModuleId,
                    ModuleType = file.ModuleType,
                    Name = file.File.Name,
                    UniqueName = $"{ Guid.NewGuid().ToString()}.{ file.File.ContentType.Split('/')[1]}",
                    Extension = file.File.ContentType
                };
                file.File.CopyToAsync(stream).Wait();
            }
            Response<AppFileModel> response = JsonConvert.DeserializeObject<Response<AppFileModel>>(await UiRequestManager.Instance.PostAsync("AppFile", "Save", JsonConvert.SerializeObject(model)));

            FileInfo fi = new FileInfo(model.FilePath);

            fi.Delete();
            return response.IsSuccess;
        }
    }
}
