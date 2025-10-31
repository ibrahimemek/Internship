using MediatR;

namespace ArkBlog.Application.Features.Commands.AuthorizationCommands.AssignRoleCommand
{
    public class AssignRoleCommandRequest : IRequest<AssignRoleCommandResponse>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Menu { get; set; }
        public Type? Type { get; set; }
    }
}