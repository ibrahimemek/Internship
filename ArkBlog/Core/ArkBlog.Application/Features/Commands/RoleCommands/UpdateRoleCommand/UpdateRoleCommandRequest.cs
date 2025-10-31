using MediatR;

namespace ArkBlog.Application.Features.Commands.RoleCommands.UpdateRoleCommand
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}