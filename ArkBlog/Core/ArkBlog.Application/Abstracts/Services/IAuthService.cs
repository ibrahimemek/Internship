using ArkBlog.Application.Dtos;
using ArkBlog.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Abstracts.Services
{
    public interface IAuthService
    {
        Task<(TokenDto, AppUser)> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);

        //Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
        //Task<TokenDto> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
