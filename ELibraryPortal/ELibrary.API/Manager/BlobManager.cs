using AutoMapper.Configuration;
using ELibrary.API.Configuration;
using ELibrary.API.Models.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Manager
{
    public class BlobManager<T> : IBlobContainer<T> where T : AppFile
    {
        public readonly IConfiguration _configuration;
        public async Task<CloudBlobContainer> CreateFolderAsync(T tmodel)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.Instance.GetConnectionString("StorageConnection"));
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=elibrarystorage;AccountKey=de8S23KSTuWPjoblw0hZSbk3YwHueULe+22S2DI9+30TmDmczi+Yy2DVcQ8UWeH9tR+izRZl/X8BPxDM8287Vg==;EndpointSuffix=core.windows.net");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                
            CloudBlobContainer container = blobClient.GetContainerReference("fileuploads");
            await container.SetPermissionsAsync(
                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob,
                    });

            await container.CreateIfNotExistsAsync();

            return container;
        }

        public async Task<CloudBlockBlob> UploadFileAsync(CloudBlobContainer container, T tmodel)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(string.Format(ConfigurationManager.Instance.GetValue("FileUploadBlobPath"), tmodel.ModuleType, tmodel.ModuleId, tmodel.UniqueName.ToLower()));
            //CloudBlockBlob blob = container.GetBlockBlobReference(string.Format("files{0}/{1}/{2}", tmodel.ModuleType, tmodel.ModuleId, tmodel.UniqueName.ToLower()));

            using (var fileStream = System.IO.File.OpenRead(tmodel.FilePath))
            {
                await blob.UploadFromStreamAsync(fileStream);

                return blob;
            }
        }
        public string SignUrl(string blobName, string blobPath, DateTime? startTime, DateTime? expiryTime)
        {
            if (!startTime.HasValue || !expiryTime.HasValue)
                return "Start time or expiry time is missing";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.Instance.GetConnectionString("StorageConnection"));
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=elibrarystorage;AccountKey=de8S23KSTuWPjoblw0hZSbk3YwHueULe+22S2DI9+30TmDmczi+Yy2DVcQ8UWeH9tR+izRZl/X8BPxDM8287Vg==;EndpointSuffix=core.windows.net");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(blobPath);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName.ToLower());

            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = startTime.Value.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = expiryTime.Value;
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

            //Generate shared access URL 
            string sasContainerToken = blockBlob.GetSharedAccessSignature(sasConstraints);

            return blockBlob.Uri + sasContainerToken;
        }
    }
}
