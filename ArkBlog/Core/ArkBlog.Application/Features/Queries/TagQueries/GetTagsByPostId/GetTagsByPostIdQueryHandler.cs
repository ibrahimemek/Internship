using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.TagQueries.GetTagsByPostId
{
    public class GetTagsByPostIdQueryHandler : IRequestHandler<GetTagsByPostIdQueryRequest, GetTagsByPostIdQueryResponse>
    {
        ITagReadRepository _TagReadRepository;

        public GetTagsByPostIdQueryHandler(ITagReadRepository tagReadRepository)
        {
            _TagReadRepository = tagReadRepository;
        }

        public Task<GetTagsByPostIdQueryResponse> Handle(GetTagsByPostIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<PostTag> tags = _TagReadRepository.GetWhere(p => p.RelevantPosts.Any(p => p.Id.ToString() == request.Id)).ToList();
            return Task.FromResult(new GetTagsByPostIdQueryResponse() { postTags = tags});
        }
    }
}
