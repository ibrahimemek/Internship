using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.PostCommands.OpenPostCommand
{
    public class OpenPostCommandHandler : IRequestHandler<OpenPostCommandRequest, OpenPostCommandResponse>
    {
        IPostReadRepository _postReadRepository;
        IPostWriteRepository _postWriteRepository;
        public OpenPostCommandHandler(IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository)
        {
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        public async Task<OpenPostCommandResponse> Handle(OpenPostCommandRequest request, CancellationToken cancellationToken)
        {
            Post post = await _postReadRepository.GetByIdAsync(request.PostId);
            post.ClickCount++;
            _postWriteRepository.Update(post);
            await _postWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}
