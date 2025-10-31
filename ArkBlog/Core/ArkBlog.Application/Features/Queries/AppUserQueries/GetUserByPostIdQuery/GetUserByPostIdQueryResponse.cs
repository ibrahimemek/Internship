using ArkBlog.Domain.Entities.Identity;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetUserByPostIdQuery
{
    public class GetUserByPostIdQueryResponse
    {
        public AppUser User { get; set; }
    }
}