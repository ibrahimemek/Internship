using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.PostQueries.GetAllPostQuery
{

    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, GetAllPostQueryResponse>
    {
        readonly IPostReadRepository _postReadRepository;

        public GetAllPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }
        

        Task<GetAllPostQueryResponse> IRequestHandler<GetAllPostQueryRequest, GetAllPostQueryResponse>.Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = _postReadRepository.Table.Include(p=>p.CoverImage).ToList();

            return Task.FromResult(new GetAllPostQueryResponse
            {
                AllPosts = posts.ToList()
            });
        }
    }
}
