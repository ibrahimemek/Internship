using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArkBlog.Application.Features.Commands.ImageFileCommands.UploadUserProfileImageFileCommand
{
    public class UploadUserProfileImageFileCommandRequest : IRequest<UploadUserProfileImageFileCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
    }
}