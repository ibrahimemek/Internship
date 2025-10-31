using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P = ArkBlog.Domain.Entities;

namespace ArkBlog.Application.Features.Queries.PostQueries.GetByIdPostQuery
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
    {
        readonly IPostReadRepository _postReadRepository;

        public GetByIdPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {

            P.Post post = await _postReadRepository.Table.Include(p=>p.Author).Include(p=> p.CoverImage).Include(p=>p.Tags).Include(p=>p.Comments).FirstOrDefaultAsync(p=>p.Id.ToString() == request.Id);
            return new() { Post = post };
        }
    }
}
