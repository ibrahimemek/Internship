using ArkBlog.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Domain.Entities
{
    public class UserProfileImageFile : File
    {
        public AppUser User {  get; set; }
        public Guid UserId { get; set; }
    }
}
