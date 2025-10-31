using ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Queries.PostQueries.FilterPostsQuery
{
    public class FilterPostsQueryResponse
    {
        public List<Post> Posts { get; set; }
    }
}