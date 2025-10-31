using MediatR;

namespace ArkBlog.Application.Features.Commands.CommentCommands.AddCommentToPostCommand
{
    public class AddCommentToPostCommandRequest : IRequest<AddCommentToPostCommandResponse>
    {
        public string Context {  get; set; }
        public string PostId { get; set; }
        public string AuthorId { get; set; }
    }
}