using ArkBlog.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Abstracts
{
    public interface ITokenHandler
    {
        public Application.Dtos.TokenDto CreateAccessToken(int minute, AppUser user);
    }
}
