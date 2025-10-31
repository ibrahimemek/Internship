using ArkBlog.Application.CustomAttributes;
using ArkBlog.Application.Enums;
using ArkBlog.Application.Features.Commands.AppUserCommands.AssignRoleToUserCommand;
using ArkBlog.Application.Features.Commands.AppUserCommands.ChangePasswordCommand;
using ArkBlog.Application.Features.Commands.AppUserCommands.CreateAppUserCommand;
using ArkBlog.Application.Features.Commands.AppUserCommands.LoginCommand;
using ArkBlog.Application.Features.Commands.AppUserCommands.UpdateUserCommand;
using ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostImageFileCommand;
using ArkBlog.Application.Features.Commands.ImageFileCommands.UploadUserProfileImageFileCommand;
using ArkBlog.Application.Features.Queries.AppUserQueries.GetAllAppUsersQuery;
using ArkBlog.Application.Features.Queries.AppUserQueries.GetByIdUserQuery;
using ArkBlog.Application.Features.Queries.AppUserQueries.GetTotalsQuery;
using ArkBlog.Application.Features.Queries.AppUserQueries.GetUserByPostIdQuery;
using ArkBlog.Application.Features.Queries.PostQueries.GetByIdPostQuery;
using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArkBlog.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] GetAllAppUsersQueryRequest getAllAppUsersQueryRequest)
        {
            var response = await _mediator.Send(getAllAppUsersQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            var response = await _mediator.Send(getByIdUserQueryRequest);
            return Ok(response);
        }


        [HttpGet("[action]/{UserId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTotals([FromRoute] GetTotalsQueryRequest getTotalsQueryRequest)
        {
            var response = await _mediator.Send(getTotalsQueryRequest);
            return Ok(response);
        }



        [HttpGet("[action]/{PostId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByPostId([FromRoute] GetUserByPostIdQueryRequest getUserByPostIdQueryRequest)
        {
            var response = await _mediator.Send(getUserByPostIdQueryRequest);
            return Ok(response);
        }

        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse response = await _mediator.Send(loginCommandRequest);
            return Ok(response);

        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateAppUserCommandRequest createAppUserCommandRequest)
        {
            CreateAppUserCommandResponse response = await _mediator.Send(createAppUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommandRequest changePasswordCommandRequest)
        {
            ChangePasswordCommandResponse response = await _mediator.Send(changePasswordCommandRequest);
            return Ok(response);
        }

        [HttpPatch("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update User", Menu = "Users")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            UpdateUserCommandResponse response = await _mediator.Send(updateUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Upload Profile Image", Menu = "Users")]
        public async Task<IActionResult> UploadProfileImage([FromForm] UploadUserProfileImageFileCommandRequest uploadUserProfileImageFileCommandRequest)
        {

            UploadUserProfileImageFileCommandResponse response = await _mediator.Send(uploadUserProfileImageFileCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        {
            AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
            return Ok(response);
        }


    }
}
