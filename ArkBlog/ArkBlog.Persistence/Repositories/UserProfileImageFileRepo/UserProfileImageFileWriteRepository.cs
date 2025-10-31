using ArkBlog.Application.Abstracts.Repositories.UserProfileImageFileRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.UserProfileImageFileRepo
{
    public class UserProfileImageFileWriteRepository : WriteRepository<UserProfileImageFile>, IUserProfileImageFileWriteRepository
    {
        public UserProfileImageFileWriteRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
