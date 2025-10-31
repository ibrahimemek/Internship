using MediatR;

namespace ArkBlog.Application.Features.Queries.PostQueries.GetAllPostQuery
{
    public class GetAllPostQueryRequest : IRequest<GetAllPostQueryResponse>
    {
    }
}