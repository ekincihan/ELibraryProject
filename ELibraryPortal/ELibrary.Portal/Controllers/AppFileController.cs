using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ELibrary.API.Configuration;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Helpers;
using ELibrary.Portal.Manager;
using ELibrary.Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class AppFileController : Controller
    {
        private readonly IFileProvider fileProvider;

        public AppFileController(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile(AppFileFilterModel file)
        {
            if (file.File == null || file.File.Length == 0)
                return Json("file not selected");

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
            Response<AppFileModel> response = JsonConvert.DeserializeObject<Response<AppFileModel>>(UiRequestManager.Instance.Post("AppFile", "Save", JsonConvert.SerializeObject(model)));

            FileInfo fi = new FileInfo(model.FilePath);

            fi.Delete();
            return Json("file uploaded");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return Content("files not selected");

            foreach (var file in files)
            {
                var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return RedirectToAction("Files");
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}