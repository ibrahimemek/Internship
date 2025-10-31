using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.TagCommands.AddTagsCommand
{
    public class AddTagsToPostCommandHandler : IRequestHandler<AddTagsToPostCommandRequest, AddTagsToPostCommandResponse>
    {
        ITagWriteRepository _tagWriteRepository;
        ITagReadRepository _tagReadRepository;
        IPostReadRepository _postReadRepository;
        IPostWriteRepository _postWriteRepository;

        public AddTagsToPostCommandHandler(ITagWriteRepository tagWriteRepository, ITagReadRepository tagReadRepository, IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository = null)
        {
            _tagWriteRepository = tagWriteRepository;
            _tagReadRepository = tagReadRepository;
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        public async Task<AddTagsToPostCommandResponse> Handle(AddTagsToPostCommandRequest request, CancellationToken cancellationToken)
        {
            List<PostTag> tags = new List<PostTag>();
            Post post = await _postReadRepository.GetByIdAsync(request.PostId);
            if (post == null)
            {
                return new AddTagsToPostCommandResponse()
                {
                    Succeeded = false
                };
            }

            post.Tags.Clear();
            foreach(var id in request.TagIds)
            {
                PostTag tag = await _tagReadRepository.GetByIdAsync(id);
                tags.Add(tag);
                
                tag.RelevantPosts.Add(post);
                _tagWriteRepository.Update(tag);
                post.Tags.Add(tag);
            }
            await _tagWriteRepository.SaveChangesAsync();
            await _postWriteRepository.SaveChangesAsync();

            return new AddTagsToPostCommandResponse()
            {
                Succeeded = true
            };
        }
    }
}
