using MediatR;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetUserByPostIdQuery
{
    public class GetUserByPostIdQueryRequest : IRequest<GetUserByPostIdQueryResponse>
    {
        public string PostId { get; set; }
    }
}