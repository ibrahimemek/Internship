using ArkBlog.Application.Abstracts.Repositories.PostCoverImageFileRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.PostCoverImageFileRepo
{
    public class PostCoverImageFileWriteRepository : WriteRepository<PostCoverImageFile>, IPostCoverImageFileWriteRepository
    {
        public PostCoverImageFileWriteRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
