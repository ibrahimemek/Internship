using ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Queries.PostQueries.SearchPostQuery
{
    public class SearchPostQueryResponse
    {
        public List<Post> SearchResult { get; set; }
    }
}