using ArkBlog.Application.Abstracts.Repositories;
using ArkBlog.Application.Abstracts.Repositories.FileRepo;
using ArkBlog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.FileRepo
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
