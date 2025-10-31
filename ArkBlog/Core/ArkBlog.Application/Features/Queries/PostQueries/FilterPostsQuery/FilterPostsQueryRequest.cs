using MediatR;

namespace ArkBlog.Application.Features.Queries.PostQueries.FilterPostsQuery
{
    public class FilterPostsQueryRequest : IRequest<FilterPostsQueryResponse>
    {
        public List<string>? PostIds { get; set; }
        public string? TagName { get; set; }
        public string? Selection { get; set; }
        public string? AuthorId { get; set; }
        public int? Count { get; set; }
        public bool? IsPublished { get; set; }
    }
}