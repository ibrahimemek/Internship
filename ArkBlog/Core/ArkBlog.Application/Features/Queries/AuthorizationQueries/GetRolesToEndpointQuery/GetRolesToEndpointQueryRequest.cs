using MediatR;

namespace ArkBlog.Application.Features.Queries.AuthorizationQueries.GetRolesToEndpointQuery
{
    public class GetRolesToEndpointQueryRequest : IRequest<GetRolesToEndpointQueryResponse>
    {
        public string Code { get; set; }
        public string Menu { get; set; }
    }
}
