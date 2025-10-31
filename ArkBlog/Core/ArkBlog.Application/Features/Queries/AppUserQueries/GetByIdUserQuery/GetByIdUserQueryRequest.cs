using MediatR;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetByIdUserQuery
{
    public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
    {
        public string Id { get; set; }

    }
}