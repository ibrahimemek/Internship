using ArkBlog.Application.Abstracts.Storages;
using Microsoft.AspNetCore.Http;

namespace ArkBlog.Infrustructure.Services.Storages
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public async Task DeleteAsync(string fileName, string pathOrContainerName)
        => await _storage.DeleteAsync(fileName, pathOrContainerName);

        public List<string> GetFiles(string pathOrContainerName)
        => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
        => _storage.HasFile(pathOrContainerName, fileName);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadRangeAsync(string pathOrContainerName, IFormFileCollection files)
        => _storage.UploadRangeAsync(pathOrContainerName, files);
        public Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file)
       => _storage.UploadAsync(pathOrContainerName, file);
    }
}
