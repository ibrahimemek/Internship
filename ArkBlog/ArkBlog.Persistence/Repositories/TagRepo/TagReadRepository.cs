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
    public class TagReadRepository : ReadRepository<PostTag>, ITagReadRepository
    {
        public TagReadRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
