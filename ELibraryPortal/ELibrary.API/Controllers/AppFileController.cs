using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Manager;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ELibrary.API.Controllers
{
    public class AppFileController : APIControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppFile _appFile;
        public AppFileController(IMapper mapper, IAppFile appFile)
        {
            _mapper = mapper;
            _appFile = appFile;
        }
        [HttpPost("Save")]
        public async Task<Response<AppFileModel>> Save([FromBody]AppFileModel appFileModel)
        {
            Response<AppFileModel> appFileModelResponse = new Response<AppFileModel>();
            try
            {
                AppFile appFile = _mapper.Map<AppFile>(appFileModel);

                BlobManager<AppFile> manager = new BlobManager<AppFile>();
                CloudBlobContainer container = await manager.CreateFolderAsync(appFile);

                if (string.IsNullOrEmpty(appFile.BlobPath))
                {
                    
                    CloudBlockBlob cloudBlockBlob = await manager.UploadFileAsync(container, appFile);
                    appFile.BlobPath = $"{cloudBlockBlob.Parent.Prefix}";
                    //appFile.BlobPath = $"{ Configuration.ConfigurationManager.Instance.GetValue("FileUploadBlobContainer")}/{appFile.BlobPath.Substring(0, appFile.BlobPath.Length - 1) }";
                    appFile.BlobPath = $"fileuploads/{appFile.BlobPath.Substring(0, appFile.BlobPath.Length - 1) }";
                }
                appFile.SignUrl = SignUrl(appFile);

                var entity = _appFile.GetT(f => f.ModuleId == appFileModel.ModuleId && f.ModuleType == (int)appFileModel.ModuleType);

                if (entity != null)
                    _appFile.Delete(entity);

                appFile = await (appFileModel.Id != Guid.Empty ? _appFile.UpdateAsync(appFile) : _appFile.AddAsync(appFile));
              
                AppFileModel model = _mapper.Map<AppFileModel>(appFile);
                appFileModelResponse.Value = model;
            }
            catch (Exception ex)
            {
                appFileModelResponse.Exception = ex;
                appFileModelResponse.IsSuccess = false;
            }
            return appFileModelResponse;
        }
        [NonAction]
        public string SignUrl(AppFile appFile)
        {
            DateTime startDate = DateTime.Now.AddMinutes(-5);
            BlobManager<AppFile> manager = new BlobManager<AppFile>();
            if (appFile == null || appFile.BlobPath == null)
                return "";
            var singUrl = manager.SignUrl(appFile.UniqueName.ToLower(), appFile.BlobPath.ToLower(), startDate, startDate.AddYears(10));
            return singUrl;
        }
    }
}