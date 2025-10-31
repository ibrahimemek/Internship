using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.TagQueries.GetAllTagsQuery
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQueryRequest, GetAllTagsQueryResponse>
    {
        ITagReadRepository _tagReadRepository;

        public GetAllTagsQueryHandler(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;
        }

        public Task<GetAllTagsQueryResponse> Handle(GetAllTagsQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetAllTagsQueryResponse()
            {
                postTags = _tagReadRepository.GetAll().ToList()
            });
        }
    }
}
