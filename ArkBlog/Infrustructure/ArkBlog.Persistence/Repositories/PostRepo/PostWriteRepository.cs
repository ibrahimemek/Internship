using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;

namespace ArkBlog.Persistence.Repositories.PostRepo
{
    public class PostWriteRepository : WriteRepository<Post>, IPostWriteRepository
    {
        public PostWriteRepository(ArkBlogDbContext context) : base(context)
        {

        }
    }
}
