using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetUserByPostIdQuery
{
    public class GetUserByPostIdQueryHandler : IRequestHandler<GetUserByPostIdQueryRequest, GetUserByPostIdQueryResponse>
    {
        IAppUserReadRepository _appUserReadRepository;

        public GetUserByPostIdQueryHandler(IAppUserReadRepository appUserReadRepository)
        {
            _appUserReadRepository = appUserReadRepository;
        }

        public async Task<GetUserByPostIdQueryResponse> Handle(GetUserByPostIdQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _appUserReadRepository.Table.Include(a => a.ProfileImageFile).FirstOrDefaultAsync(a => a.Posts.Any(p=> p.Id.ToString() == request.PostId));
            return new GetUserByPostIdQueryResponse() { User = user };
        }
    }
}
