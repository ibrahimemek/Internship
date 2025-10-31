using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Application.Features.Queries.PostQueries.GetAllPostQuery;
using ArkBlog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetAllAppUsersQuery
{
    public class GetAllAppUsersQueryHandler : IRequestHandler<GetAllAppUsersQueryRequest, GetAllAppUsersQueryResponse>
    {
        readonly IAppUserReadRepository _appUserReadRepository;

        public GetAllAppUsersQueryHandler(IAppUserReadRepository appUserReadRepository)
        {
            _appUserReadRepository = appUserReadRepository;
        }
        public Task<GetAllAppUsersQueryResponse> Handle(GetAllAppUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var allAppUsers = _appUserReadRepository.Table.Include(a=>a.Posts).Include(a=>a.ProfileImageFile);

            return Task.FromResult(new GetAllAppUsersQueryResponse
            {
                AllAppUsers = allAppUsers.ToList()
            });
        }
    }
}
