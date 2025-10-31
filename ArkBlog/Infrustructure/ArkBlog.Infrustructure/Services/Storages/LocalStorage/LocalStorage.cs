using ArkBlog.Application.Abstracts.Storages.LocalStorage;
using ArkBlog.Infrustructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ArkBlog.Infrustructure.Services.Storages.LocalStorage
{
    public class LocalStorage : Storage, ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string fileName, string path)
        => File.Delete($"{path}\\{fileName}");


        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        => File.Exists($"{path}\\{fileName}");

        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }

        protected string FileRename(string pathOrContainerName, IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string newFileName = NameOperation.CharacterRegulatory(fileName);
            string[] allFiles = Directory.GetFiles(pathOrContainerName, $"{newFileName}*{extension}");
            string result = $"{newFileName}";
            var filesCount = allFiles.Length;
            if (filesCount > 0)
                result += $"-{(filesCount + 1)}";
            result += $"{extension}";
            return result;

        }
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadRangeAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = FileRename(uploadPath, file);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{uploadPath}\\{fileNewName}"));
            }

            return datas;

            //todo Eger ki yukaridaki if gecerli degilse, burada dosyalarin sunucuda yüklenirken hata alindigina dair uyarici bir exception olusturulup firlatilmasi gerekiyor.
        }

        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string path, IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            
            string fileNewName = FileRename(uploadPath, file);

            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
            return (fileNewName, $"{path}\\{fileNewName}");
            

            //todo Eger ki yukaridaki if gecerli degilse, burada dosyalarin sunucuda yüklenirken hata alindigina dair uyarici bir exception olusturulup firlatilmasi gerekiyor.
        }
    }
}
