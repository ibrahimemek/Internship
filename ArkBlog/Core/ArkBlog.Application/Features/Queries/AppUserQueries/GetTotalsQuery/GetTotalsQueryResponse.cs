namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetTotalsQuery
{
    public class GetTotalsQueryResponse
    {
        public int TotalClickCount { get; set; }
        public int TotalPostCount { get; set; }
        public int TotalCommentCount { get; set; }
    }
}