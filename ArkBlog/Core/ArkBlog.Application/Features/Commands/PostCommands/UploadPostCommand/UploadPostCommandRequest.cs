using MediatR;

namespace ArkBlog.Application.Features.Commands.PostCommands.UploadPostCommand
{
    public class UploadPostCommandRequest : IRequest<UploadPostCommandResponse>
    {
        public string? PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string AuthorId { get; set; }
        public bool IsPublished { get; set; }

    }
}