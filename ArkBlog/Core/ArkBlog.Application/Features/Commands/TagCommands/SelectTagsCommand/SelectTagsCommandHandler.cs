using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.TagCommands.SelectTagsCommand
{
    public class SelectTagsCommandHandler : IRequestHandler<SelectTagsCommandRequest, SelectTagsCommandResponse>
    {
        IPostReadRepository _postReadRepository;
        IPostWriteRepository _postWriteRepository;
        ITagReadRepository _tagReadRepository;

        public SelectTagsCommandHandler(IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository, ITagReadRepository tagReadRepository)
        {
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
            _tagReadRepository = tagReadRepository;
        }

        public async Task<SelectTagsCommandResponse> Handle(SelectTagsCommandRequest request, CancellationToken cancellationToken)
        {
            Post post = await _postReadRepository.GetByIdAsync(request.PostId);
            List<PostTag> taglist = new List<PostTag>();
            foreach (var tagId in request.TagIds)
            {
                PostTag tag = await _tagReadRepository.GetByIdAsync(tagId);
                if (tag != null) taglist.Add(tag);
            }
            post.Tags = taglist;
            _postWriteRepository.Update(post);
            await _postWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}
