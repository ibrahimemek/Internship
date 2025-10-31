using ArkBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Abstracts.Repositories.CommentRepo
{
    public interface ICommentWriteRepository: IWriteRepository<Comment>
    {
    }
}
