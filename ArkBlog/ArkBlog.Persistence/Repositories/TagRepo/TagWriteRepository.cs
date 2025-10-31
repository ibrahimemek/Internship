using ArkBlog.Application.Abstracts.Repositories;
using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.TagRepo
{
    public class TagWriteRepository : WriteRepository<PostTag>, ITagWriteRepository
    {
        public TagWriteRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
