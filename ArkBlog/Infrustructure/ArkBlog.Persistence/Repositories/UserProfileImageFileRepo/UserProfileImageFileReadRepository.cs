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
    public class UserProfileImageFileReadRepository : ReadRepository<UserProfileImageFile>, IUserProfileImageFileReadRepository
    {
        public UserProfileImageFileReadRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
