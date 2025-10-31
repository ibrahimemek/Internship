using MediatR;

namespace ArkBlog.Application.Features.Queries.RoleQueries.GetRoleByIdQuery
{
    public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}