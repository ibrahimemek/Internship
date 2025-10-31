using MediatR;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetTotalsQuery
{
    public class GetTotalsQueryRequest: IRequest<GetTotalsQueryResponse>
    {
        public string UserId { get; set; }
    }
}