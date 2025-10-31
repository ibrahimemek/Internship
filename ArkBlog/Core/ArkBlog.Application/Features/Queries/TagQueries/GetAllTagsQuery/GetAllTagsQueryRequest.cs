using MediatR;

namespace ArkBlog.Application.Features.Queries.TagQueries.GetAllTagsQuery
{
    public class GetAllTagsQueryRequest : IRequest<GetAllTagsQueryResponse>
    {
    }
}