using ArkBlog.Application.CustomAttributes;
using ArkBlog.Application.Enums;
using ArkBlog.Application.Features.Commands.AuthorizationCommands.AssignRoleCommand;
using ArkBlog.Application.Features.Queries.AuthorizationQueries.GetRolesToEndpointQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArkBlog.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Endpoint", Menu = "Auth")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQueryRequest rolesToEndpointQueryRequest)
        {
            GetRolesToEndpointQueryResponse response = await _mediator.Send(rolesToEndpointQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Assign Role To Endpoint", Menu = "Auth")]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}
