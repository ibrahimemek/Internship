using ArkBlog.Application.Abstracts.Repositories.CommentRepo;
using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.CommentCommands.AddCommentToPostCommand
{
    public class AddCommentToPostCommandHandler : IRequestHandler<AddCommentToPostCommandRequest, AddCommentToPostCommandResponse>
    {
        IAppUserReadRepository _userReadRepository;
        IPostReadRepository _postReadRepository;
        ICommentReadRepository _commentReadRepository;
        ICommentWriteRepository _commentWriteRepository;

        public AddCommentToPostCommandHandler(IAppUserReadRepository userReadRepository, IPostReadRepository postReadRepository, ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _postReadRepository = postReadRepository;
            _commentReadRepository = commentReadRepository;
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<AddCommentToPostCommandResponse> Handle(AddCommentToPostCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser author = await _userReadRepository.Table.Include(a => a.Comments).FirstOrDefaultAsync(a => a.Id.ToString() == request.AuthorId);
            Post post = await _postReadRepository.Table.Include(p=>p.Comments).FirstOrDefaultAsync(p => p.Id.ToString() == request.PostId);
            if (post == null) return new AddCommentToPostCommandResponse() { Comment = null };
            Comment comment = new Comment() { Author = author, Context = request.Context, Post = post };
            await _commentWriteRepository.AddAsync(comment);
            await _commentWriteRepository.SaveChangesAsync();
            return new AddCommentToPostCommandResponse() { Comment = comment };
            
        }
    }
}
