using ArkBlog.Application.CustomAttributes;
using ArkBlog.Application.Enums;
using ArkBlog.Application.Features.Commands.TagCommands.AddTagsCommand;
using ArkBlog.Application.Features.Commands.TagCommands.CreateTagCommand;
using ArkBlog.Application.Features.Commands.TagCommands.SelectTagsCommand;
using ArkBlog.Application.Features.Queries.TagQueries.GetAllTagsQuery;
using ArkBlog.Application.Features.Queries.TagQueries.GetTagsByPostId;
using ArkBlog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArkBlog.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly IMediator _mediator;


        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]/{Id}")]
        [AllowAnonymous]
        public async Task<List<PostTag>> GetTagsOfPost([FromRoute] GetTagsByPostIdQueryRequest getTagsByPostIdQueryRequest)
        {
            var response = await _mediator.Send(getTagsByPostIdQueryRequest);
            return response.postTags;
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Tag", Menu = "Tags")]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagCommandRequest createTagCommandRequest)
        {
            CreateTagCommandResponse response = await _mediator.Send(createTagCommandRequest);
            return Ok(response);
        }



        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Add Tag To Post", Menu = "Tags")]
        public async Task<IActionResult> AddTagsToPost([FromBody] AddTagsToPostCommandRequest addTagsCommandRequest)
        {
            AddTagsToPostCommandResponse response = await _mediator.Send(addTagsCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Select Tags Of Post", Menu = "Tags")]
        public async Task<IActionResult> SelectTags([FromBody] SelectTagsCommandRequest selectTagsCommandRequest)
        {
            SelectTagsCommandResponse response = await _mediator.Send(selectTagsCommandRequest);
            return Ok(response);
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<List<PostTag>> GetTags([FromRoute] GetAllTagsQueryRequest getAllTagsQueryRequest)
        {
            var response = await _mediator.Send(getAllTagsQueryRequest);
            return response.postTags;

        }


    }
}
