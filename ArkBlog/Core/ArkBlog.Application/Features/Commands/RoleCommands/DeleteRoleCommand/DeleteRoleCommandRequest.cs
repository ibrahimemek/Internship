using MediatR;

namespace ArkBlog.Application.Features.Commands.RoleCommands.DeleteRoleCommand
{
    public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}