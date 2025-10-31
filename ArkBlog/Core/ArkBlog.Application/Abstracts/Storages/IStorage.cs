using Microsoft.AspNetCore.Http;

namespace ArkBlog.Application.Abstracts.Storages
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadRangeAsync(string pathOrContainerName, IFormFileCollection files);
        Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file);


        Task DeleteAsync(string fileName, string pathOrContainerName);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    }
}
