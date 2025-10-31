using MediatR;

namespace ArkBlog.Application.Features.Commands.RoleCommands.CreateRoleCommand
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}