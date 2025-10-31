using ArkBlog.Application.Abstracts.Repositories.PostCoverImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.UserProfileImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Application.Abstracts.Storages;
using ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostImageFileCommand;
using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.ImageFileCommands.UploadUserProfileImageFileCommand
{
    public class UploadUserProfileImageFileCommandHandler : IRequestHandler<UploadUserProfileImageFileCommandRequest, UploadUserProfileImageFileCommandResponse>
    {
        IStorageService _storageService;
        IAppUserReadRepository _appUserReadRepository;
        IUserProfileImageFileReadRepository _userProfileImageFileReadRepository;
        IUserProfileImageFileWriteRepository _userProfileImageFileWriteRepository;


        public UploadUserProfileImageFileCommandHandler(IStorageService storageService, IAppUserReadRepository appUserReadRepository,
            IUserProfileImageFileReadRepository userProfileImageFileReadRepository, IUserProfileImageFileWriteRepository userProfileImageFileWriteRepository)
        {
            _storageService = storageService;
            _appUserReadRepository = appUserReadRepository;
            _userProfileImageFileReadRepository = userProfileImageFileReadRepository;
            _userProfileImageFileWriteRepository = userProfileImageFileWriteRepository;
        }

        public async Task<UploadUserProfileImageFileCommandResponse> Handle(UploadUserProfileImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            (string fileName, string pathOrContainerName) result;
            AppUser user = await _appUserReadRepository.GetByIdAsync(request.Id);

            IQueryable<UserProfileImageFile> prevProf = _userProfileImageFileReadRepository.GetWhere(p => p.User == user);
            if (prevProf.Any()) _userProfileImageFileWriteRepository.RemoveRange(prevProf.ToList());



            result = await _storageService.UploadAsync("user-profile-images", request.File);


            UserProfileImageFile userImageFile = new UserProfileImageFile
            {
                FileName = result.fileName,
                Path = result.pathOrContainerName,
                Storage = _storageService.StorageName,
                User = user
            };



            await _userProfileImageFileWriteRepository.AddAsync(
                userImageFile
            );

            await _userProfileImageFileWriteRepository.SaveChangesAsync();

            user.ProfileImageFile = userImageFile;

            return new UploadUserProfileImageFileCommandResponse()
            {
                PathOrContainer = result.pathOrContainerName
            };
        }
    }
}
