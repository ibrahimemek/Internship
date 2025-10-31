using MediatR;

namespace ArkBlog.Application.Features.Commands.AppUserCommands.ChangePasswordCommand
{
    public class ChangePasswordCommandRequest : IRequest<ChangePasswordCommandResponse>
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }

    }
}