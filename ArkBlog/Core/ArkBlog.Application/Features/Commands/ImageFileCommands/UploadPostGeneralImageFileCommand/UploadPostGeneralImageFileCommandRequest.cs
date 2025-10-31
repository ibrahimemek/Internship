using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostImageFileCommand
{
    public class UploadPostGeneralImageFileCommandRequest : IRequest<UploadPostGeneralImageFileCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
    }
}