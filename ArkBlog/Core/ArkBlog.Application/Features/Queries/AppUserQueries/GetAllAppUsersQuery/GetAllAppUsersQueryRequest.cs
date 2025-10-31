using MediatR;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetAllAppUsersQuery
{
    public class GetAllAppUsersQueryRequest : IRequest<GetAllAppUsersQueryResponse>
    {
    }
}