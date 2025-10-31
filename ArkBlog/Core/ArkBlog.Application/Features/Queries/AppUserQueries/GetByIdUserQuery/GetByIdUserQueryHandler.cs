using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetByIdUserQuery
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        IAppUserReadRepository _appUserReadRepository;

        public GetByIdUserQueryHandler(IAppUserReadRepository appUserReadRepository)
        {
            _appUserReadRepository = appUserReadRepository;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _appUserReadRepository.Table.Include(a=> a.ProfileImageFile).FirstOrDefaultAsync(a=> a.Id.ToString() == request.Id);
            return new() { AppUser = user };
        }
    }
}
