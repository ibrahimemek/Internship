using P = ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Queries.PostQueries.GetByIdPostQuery
{
    public class GetByIdPostQueryResponse
    {
        public P.Post Post { get; set; }
    }
}
