using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using ArkBlog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArkBlog.Persistence.Repositories.UserRepo
{
    public class AppUserReadRepository : IAppUserReadRepository
    {
        private readonly ArkBlogDbContext _context;

        public AppUserReadRepository(ArkBlogDbContext context)
        {
            _context = context;
        }

        public DbSet<AppUser> Table => _context.Set<AppUser>();

        public IQueryable<AppUser> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return query;
        }

        public async Task<AppUser> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id.ToString() == id);
        }

        public async Task<AppUser> GetSingleAsync(Expression<Func<AppUser, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<AppUser> GetWhere(Expression<Func<AppUser, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query.AsNoTracking();
            return query;
        }

        public async Task<bool> HasAccountAsync(string email, string userName)
        {
            AppUser user = await GetSingleAsync(a => a.Email == email ||  a.UserName == userName);
            if (user == null)
                return false;
            return true;
        }
    }
}
