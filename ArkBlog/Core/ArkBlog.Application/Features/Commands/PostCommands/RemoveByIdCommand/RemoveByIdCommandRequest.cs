using MediatR;

namespace ArkBlog.Application.Features.Commands.PostCommands.RemoveByIdCommand
{
    public class RemoveByIdCommandRequest : IRequest<RemoveByIdCommandResponse>
    {
        public string Id { get; set; }
    }
}