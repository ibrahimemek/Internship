using P = ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Queries.PostQueries.GetAllPostQuery
{
    public class GetAllPostQueryResponse
    {
        public List<P.Post> AllPosts {  get; set; }
    }
}