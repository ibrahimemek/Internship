using MediatR;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetRolesToAppUserQuery
{
    public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
    {
        public string UserId { get; set; }
    }
}