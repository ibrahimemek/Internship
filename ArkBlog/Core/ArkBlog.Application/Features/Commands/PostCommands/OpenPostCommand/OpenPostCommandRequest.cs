using MediatR;

namespace ArkBlog.Application.Features.Commands.PostCommands.OpenPostCommand
{
    public class OpenPostCommandRequest :IRequest<OpenPostCommandResponse>
    {
        public string PostId { get; set; }
    }
}