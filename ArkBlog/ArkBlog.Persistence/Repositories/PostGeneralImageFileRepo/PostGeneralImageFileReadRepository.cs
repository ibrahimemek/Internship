using ArkBlog.Application.Abstracts.Repositories.PostGeneralImageFileRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.PostGeneralImageFileRepo
{
    public class PostGeneralImageFileReadRepository : ReadRepository<PostGeneralImageFile>, IPostGeneralImageFileReadRepository
    {
        public PostGeneralImageFileReadRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
