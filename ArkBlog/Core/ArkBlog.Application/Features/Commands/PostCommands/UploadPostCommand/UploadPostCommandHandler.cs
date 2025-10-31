using ArkBlog.Application.Abstracts.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.PostCommands.UploadPostCommand
{
    public class UploadPostCommandHandler : IRequestHandler<UploadPostCommandRequest, UploadPostCommandResponse>
    {
        IPostService _postService;

        public UploadPostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<UploadPostCommandResponse> Handle(UploadPostCommandRequest request, CancellationToken cancellationToken)
        {
            bool succeeded = false;
            string id = "";
            if (request.Content == "")
                (succeeded, id) = await _postService.CreateAsync(request.AuthorId);
            else if (request.IsPublished)
                succeeded = await _postService.PublishAsync(request.PostId, request.Title, request.Content, request.AuthorId);
            else
                succeeded = await _postService.SaveDraftAsync(request.PostId, request.Title, request.Content, request.AuthorId);
            if (succeeded)
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return new UploadPostCommandResponse()
                    {
                        Succeeded = true,
                        Message = "success",
                        Id = id
                    };
                }
                return new UploadPostCommandResponse()
                {
                    Succeeded = true,
                    Message = "success",
                    Id = id
                };
            }
                
            return new UploadPostCommandResponse()
            {
                Succeeded = succeeded,
                Message = "Error in post service"
            };


        }
    }
}
