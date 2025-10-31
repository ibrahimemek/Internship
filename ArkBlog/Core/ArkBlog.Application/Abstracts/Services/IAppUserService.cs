using ArkBlog.Application.Dtos.AppUserDtos;
using ArkBlog.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Abstracts.Services
{
    public interface IAppUserService
    {
        Task<CreateAppUserResponseDto> CreateAsync(CreateAppUserDto model);
        //Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        //Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
        //Task<List<ListUser>> GetAllUsersAsync(int page, int size);
        //int TotalUsersCount { get; }
        Task AssignRoleToUserAsnyc(string userId, string[] roles);
        Task<string[]> GetRolesToUserAsync(string userIdOrName);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
