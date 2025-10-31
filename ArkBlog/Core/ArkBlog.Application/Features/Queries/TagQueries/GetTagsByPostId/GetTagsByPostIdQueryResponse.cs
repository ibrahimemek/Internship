using ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Queries.TagQueries.GetTagsByPostId
{
    public class GetTagsByPostIdQueryResponse
    {
        public List<PostTag> postTags;
    }
}