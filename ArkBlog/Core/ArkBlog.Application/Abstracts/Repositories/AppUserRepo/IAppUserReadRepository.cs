using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArkBlog.Application.Abstracts.Repositories.UserRepo
{
    public interface IAppUserReadRepository
    {
        DbSet<AppUser> Table { get; }
        IQueryable<AppUser> GetAll(bool tracking = true);
        IQueryable<AppUser> GetWhere(Expression<Func<AppUser, bool>> method, bool tracking = true);
        Task<AppUser> GetByIdAsync(string id, bool tracking = true);
        Task<AppUser> GetSingleAsync(Expression<Func<AppUser, bool>> method, bool tracking = true);

        Task<bool> HasAccountAsync(string email, string userName);
    }
}
