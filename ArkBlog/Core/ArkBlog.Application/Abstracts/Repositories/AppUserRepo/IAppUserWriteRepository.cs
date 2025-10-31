using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;

namespace ArkBlog.Application.Abstracts.Repositories.UserRepo
{
    public interface IAppUserWriteRepository
    {
        Task<bool> AddAsync(AppUser model);
        Task<bool> AddRangeAsync(List<AppUser> models);
        bool Remove(AppUser model);
        bool RemoveRange(List<AppUser> models);
        Task<bool> RemoveAsync(string id);

        bool Update(AppUser model);
        Task<int> SaveChangesAsync();
    }
}
