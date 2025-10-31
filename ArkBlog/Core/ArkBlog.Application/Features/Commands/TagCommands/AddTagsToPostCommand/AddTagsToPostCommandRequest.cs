using ArkBlog.Domain.Entities;
using MediatR;

namespace ArkBlog.Application.Features.Commands.TagCommands.AddTagsCommand
{
    public class AddTagsToPostCommandRequest : IRequest<AddTagsToPostCommandResponse>
    {
        public List<string> TagIds { get; set; }
        public string PostId { get; set; }

    }
}