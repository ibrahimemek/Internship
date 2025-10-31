using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using ArkBlog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ArkBlog.Persistence.Repositories.UserRepo
{
    public class AppUserWriteRepository : IAppUserWriteRepository
    {
        private readonly ArkBlogDbContext _context;

        public AppUserWriteRepository(ArkBlogDbContext context)
        {
            _context = context;
        }
        public DbSet<AppUser> Table => _context.Set<AppUser>();

        public async Task<bool> AddAsync(AppUser model)
        {
            EntityEntry<AppUser> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;

        }

        public async Task<bool> AddRangeAsync(List<AppUser> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(AppUser model)
        {

            EntityEntry<AppUser> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;

        }

        public async Task<bool> RemoveAsync(string id)
        {
            AppUser model = await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id);
            return Remove(model);
        }

        public bool RemoveRange(List<AppUser> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(AppUser model)
        {
            EntityEntry<AppUser> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
