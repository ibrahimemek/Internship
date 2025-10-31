using MediatR;

namespace ArkBlog.Application.Features.Queries.PostQueries.SearchPostQuery
{
    public class SearchPostQueryRequest : IRequest<SearchPostQueryResponse>
    {
        public string SearchKey { get; set; }
    }
}