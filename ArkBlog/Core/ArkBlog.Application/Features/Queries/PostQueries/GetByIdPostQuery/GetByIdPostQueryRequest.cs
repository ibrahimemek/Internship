using MediatR;

namespace ArkBlog.Application.Features.Queries.PostQueries.GetByIdPostQuery
{
    public class GetByIdPostQueryRequest : IRequest<GetByIdPostQueryResponse>
    {
        public string Id { get; set; }
    }
}
