using ArkBlog.Application.CustomAttributes;
using ArkBlog.Application.Enums;
using ArkBlog.Application.Features.Commands.CommentCommands.AddCommentToPostCommand;
using ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostImageFileCommand;
using ArkBlog.Application.Features.Commands.PostCommands.OpenPostCommand;
using ArkBlog.Application.Features.Commands.PostCommands.RemoveByIdCommand;
using ArkBlog.Application.Features.Commands.PostCommands.UploadPostCommand;
using ArkBlog.Application.Features.Queries.PostQueries.FilterPostsQuery;
using ArkBlog.Application.Features.Queries.PostQueries.GetAllPostQuery;
using ArkBlog.Application.Features.Queries.PostQueries.GetByIdPostQuery;
using ArkBlog.Application.Features.Queries.PostQueries.SearchPostQuery;
using ArkBlog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArkBlog.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;


        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<Post> Get([FromRoute] GetByIdPostQueryRequest getByIdPostQueryRequest)
        {
            var response = await _mediator.Send(getByIdPostQueryRequest);
            return response.Post;
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Post", Menu = "Posts")]
        public async Task<bool> Remove([FromRoute] RemoveByIdCommandRequest removeByIdCommandRequest)
        {
            var response = await _mediator.Send(removeByIdCommandRequest);
            return response.Succeeded;
        }





        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Post>> Get([FromRoute] GetAllPostQueryRequest getAllPostQueryRequest)
        {
            var response = await _mediator.Send(getAllPostQueryRequest);
            return response.AllPosts;

        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> OpenPost([FromBody] OpenPostCommandRequest openPostCommandRequest)
        {
            var response = await _mediator.Send(openPostCommandRequest);
            return Ok(response);
        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Filter([FromBody] FilterPostsQueryRequest filterPostsQueryRequest)
        {
            var response = await _mediator.Send(filterPostsQueryRequest);
            return Ok(response);
        }



        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Upload Post", Menu = "Posts")]
        public async Task<IActionResult> Upload([FromBody] UploadPostCommandRequest uploadPostCommandRequest)
        {
            var response = await _mediator.Send(uploadPostCommandRequest);
            return Ok(response);
        }



        [HttpPost("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Add Comment To Post", Menu = "Posts")]
        public async Task<IActionResult> AddCommentToPost([FromBody] AddCommentToPostCommandRequest addCommentToPostCommandRequest)
        {
            var response = await _mediator.Send(addCommentToPostCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromBody] SearchPostQueryRequest searchPostQueryRequest)
        {
            var response = await _mediator.Send(searchPostQueryRequest);
            return Ok(response);
        }














        [HttpPost("[action]")]
        public async Task<IActionResult> UploadCoverImage([FromForm] UploadPostCoverImageFileCommandRequest uploadPostImageFileCommandRequest)
        {
            
            UploadPostCoverImageFileCommandResponse response = await _mediator.Send(uploadPostImageFileCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadGeneralImage([FromForm] UploadPostGeneralImageFileCommandRequest uploadPostImageFileCommandRequest)
        {

            UploadPostGeneralImageFileCommandResponse response = await _mediator.Send(uploadPostImageFileCommandRequest);
            return Ok(response);
        }
    }
}
