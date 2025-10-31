using ArkBlog.Domain.Entities;
using MediatR;

namespace ArkBlog.Application.Features.Commands.AppUserCommands.UpdateUserCommand
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public UserProfileImageFile? UserProfileImageFile { get; set; }

    }
}