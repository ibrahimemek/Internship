using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Application.Abstracts.Services;
using ArkBlog.Application.Dtos.AppUserDtos;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ArkBlog.Application.Features.Commands.AppUserCommands.CreateAppUserCommand
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        readonly IAppUserService _userService;
        readonly IAppUserReadRepository _appUserReadRepository;
        public CreateAppUserCommandHandler(IAppUserService userService, IAppUserReadRepository appUserReadRepository)
        {
            _userService = userService;
            _appUserReadRepository = appUserReadRepository;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            bool hasAcc = await _appUserReadRepository.HasAccountAsync(request.Email, request.Password);
            if (hasAcc)
                return new CreateAppUserCommandResponse()
                {
                    Message = "There is already with that username or email",
                    Succeeded = false
                };


            CreateAppUserResponseDto response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.Username,

            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };

            //throw new UserCreateFailedException();
        }
    }
}
