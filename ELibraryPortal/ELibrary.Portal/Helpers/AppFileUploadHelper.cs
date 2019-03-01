﻿using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Helpers
{
    public class AppFileUploadHelper : SingletonBase<AppFileUploadHelper>
    {
        public async Task<Response<AppFileModel>> UploadFile(AppFileFilterModel file)
        {
            Response<AppFileModel> response= new Response<AppFileModel>();
            if (file.File == null)
            {
                response.IsSuccess = false;
                return response;
            }

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
                    UniqueName = $"{ Guid.NewGuid().ToString()}.{ file.File.ContentType.Split('/')[1].Replace("+zip", "") }",
                    Extension = file.File.ContentType.Replace("+zip", "")
                };
                file.File.CopyToAsync(stream).Wait();
            }
             response = JsonConvert.DeserializeObject<Response<AppFileModel>>(await UiRequestManager.Instance.PostAsync("AppFile", "Save", JsonConvert.SerializeObject(model)));

            FileInfo fi = new FileInfo(model.FilePath);

            fi.Delete();
            return response;
        }
    }
}