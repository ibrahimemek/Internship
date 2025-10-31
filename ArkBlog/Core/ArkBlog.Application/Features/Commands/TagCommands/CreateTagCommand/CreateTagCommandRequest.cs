using MediatR;

namespace ArkBlog.Application.Features.Commands.TagCommands.CreateTagCommand
{
    public class CreateTagCommandRequest : IRequest<CreateTagCommandResponse>
    {
        public string TagName { get; set; }
    }
}