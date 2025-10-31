using MediatR;

namespace ArkBlog.Application.Features.Commands.TagCommands.SelectTagsCommand
{
    public class SelectTagsCommandRequest : IRequest<SelectTagsCommandResponse>
    {
        public string PostId { get; set; }
        public List<string> TagIds { get; set; }
    }
}