using ArkBlog.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ArkBlog.Application.Abstracts.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table {  get; }
    }
}
