using ELibrary.Entities.Concrete;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models.Abstract
{
    public interface IBlobContainer<T> where T : AppFile
    {
        Task<CloudBlobContainer> CreateFolderAsync(T tmodel);
        Task<CloudBlockBlob> UploadFileAsync(CloudBlobContainer container, T tmodel);
        string SignUrl(string blobName, string blobPath, DateTime? startTime, DateTime? expiryTime);
    }
}
