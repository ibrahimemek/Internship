using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.AppUserCommands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        IAppUserReadRepository _appUserReadRepository;
        IAppUserWriteRepository _appUserWriteRepository;

        public UpdateUserCommandHandler(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository)
        {
            _appUserReadRepository = appUserReadRepository;
            _appUserWriteRepository = appUserWriteRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _appUserReadRepository.Table.Include(a=>a.ProfileImageFile).FirstOrDefaultAsync(a=>a.Id.ToString() == request.Id);
            if (user == null) return new();
            if (request.UserName != null)
            {
                var query = _appUserReadRepository.GetWhere(a => a.UserName == request.UserName);
                if (query != null) return new();
                user.UserName = request.UserName;
            }
            if (request.NameSurname != null) user.NameSurname = request.NameSurname;
            if (request.UserProfileImageFile != null) user.ProfileImageFile = request.UserProfileImageFile;
            _appUserWriteRepository.Update(user);
            await _appUserWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}
