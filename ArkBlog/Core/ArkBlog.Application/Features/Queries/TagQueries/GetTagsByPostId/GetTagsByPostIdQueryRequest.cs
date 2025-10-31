using MediatR;

namespace ArkBlog.Application.Features.Queries.TagQueries.GetTagsByPostId
{
    public class GetTagsByPostIdQueryRequest : IRequest<GetTagsByPostIdQueryResponse>
    {
        public string Id { get; set; }
    }
}