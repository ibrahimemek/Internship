using ArkBlog.Application.Abstracts.Repositories.CommentRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.CommentRepo
{
    public class CommentWriteRepository : WriteRepository<Comment>, ICommentWriteRepository
    {
        public CommentWriteRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
