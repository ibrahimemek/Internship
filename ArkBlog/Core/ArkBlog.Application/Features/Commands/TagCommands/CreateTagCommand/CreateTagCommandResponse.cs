using ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Commands.TagCommands.CreateTagCommand
{
    public class CreateTagCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}