using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ArkBlog.Persistence.Repositories.PostRepo
{
    public class PostReadRepository : ReadRepository<Post>, IPostReadRepository
    {
        public PostReadRepository(ArkBlogDbContext context) : base(context)
        {
        }


        

    }
}
