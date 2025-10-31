using MediatR;

namespace ArkBlog.Application.Features.Commands.AppUserCommands.AssignRoleToUserCommand
{
    public class AssignRoleToUserCommandRequest : IRequest<AssignRoleToUserCommandResponse>
    {
        public string UserId { get; set; }
        public string[] Roles { get; set; }
    }
}