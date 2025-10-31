using MediatR;

namespace ArkBlog.Application.Features.Queries.RoleQueries.GetRolesQuery
{
    public class GetRolesQueryRequest : IRequest<GetRolesQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
