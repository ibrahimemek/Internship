using ArkBlog.Application.Abstracts.Storages.AzureStorage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ArkBlog.Infrustructure.Services.Storages.AzureStorage
{
    public class AzureStorage : Storage, IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }
        protected async Task<string> FileRenameAsync(string containerName, IFormFile file, BlobServiceClient blobServiceClient)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Ensure the container exists
            await blobContainerClient.CreateIfNotExistsAsync();

            // List blobs with the same name pattern
            var blobs = blobContainerClient.GetBlobsAsync(prefix: fileName);
            int similarFileCount = 0;

            await foreach (BlobItem blobItem in blobs)
            {
                if (blobItem.Name.StartsWith(fileName) && blobItem.Name.EndsWith(extension))
                {
                    similarFileCount++;
                }
            }

            string newFileName = fileName;
            if (similarFileCount > 0)
            {
                newFileName += $"-{similarFileCount + 1}";
            }
            newFileName += extension;

            return newFileName;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadRangeAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(containerName, file, _blobServiceClient);

                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
            }
            return datas;
        }

        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string containerName, IFormFile file)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            
            string fileNewName = await FileRenameAsync(containerName, file, _blobServiceClient);

            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
            await blobClient.UploadAsync(file.OpenReadStream());
            return(fileNewName, $"{containerName}/{fileNewName}");
           
        }

    }
}
