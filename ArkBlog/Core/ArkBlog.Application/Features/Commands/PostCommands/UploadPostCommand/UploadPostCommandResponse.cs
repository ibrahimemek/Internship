namespace ArkBlog.Application.Features.Commands.PostCommands.UploadPostCommand
{
    public class UploadPostCommandResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public string? Id { get; set; }
    }
}