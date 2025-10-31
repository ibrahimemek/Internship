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

namespace ArkBlog.Application.Features.Queries.AppUserQueries.GetTotalsQuery
{
    public class GetTotalsQueryHandler : IRequestHandler<GetTotalsQueryRequest, GetTotalsQueryResponse>
    {
        IAppUserReadRepository _appUserReadRepository;
        IPostReadRepository _postReadRepository;

        public GetTotalsQueryHandler(IAppUserReadRepository appUserReadRepository, IPostReadRepository postReadRepository)
        {
            _appUserReadRepository = appUserReadRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<GetTotalsQueryResponse> Handle(GetTotalsQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _appUserReadRepository.Table.Include(a => a.Posts).FirstOrDefaultAsync(a => a.Id.ToString() == request.UserId);
            int totalPost = 0;
            int totalComment = 0;
            int totalClick = 0;
            foreach (Post eachPost in user.Posts)
            {
                Post post = await _postReadRepository.Table.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == eachPost.Id);
                totalPost++;
                totalComment += post.Comments.Count;
                totalClick += post.ClickCount;
            }
            return new GetTotalsQueryResponse() {TotalClickCount = totalClick, TotalCommentCount = totalComment, TotalPostCount = totalPost};
        }
    }
}
