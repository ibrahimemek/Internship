using ArkBlog.Domain.Entities.Identity;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetAllAppUsersQuery
{
    public class GetAllAppUsersQueryResponse
    {
        public List<AppUser> AllAppUsers {get; set;}
    }
}