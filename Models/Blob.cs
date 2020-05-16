using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace EcomProject.Models
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            var storageCred = new StorageCredentials(configuration["Storage-Account-Name"], configuration["BlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCred, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();

        }
        public async Task<CloudBlobContainer> GetContianer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();

            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            return cbc;
        }

        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContianer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }

        public async Task UploadFile(string containerName, string fileName, string saveLocation)
        {
            var container = await GetContianer(containerName);
            var blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(saveLocation);
        }

        public async Task DeleteBlob(string containerName, string fileName)
        {
            var container = await GetContianer(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.DeleteAsync();
        }
    }
}