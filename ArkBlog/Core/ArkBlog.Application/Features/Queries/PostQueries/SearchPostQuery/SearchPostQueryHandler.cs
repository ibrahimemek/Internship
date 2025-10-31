using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Queries.PostQueries.SearchPostQuery
{
    public class SearchPostQueryHandler : IRequestHandler<SearchPostQueryRequest, SearchPostQueryResponse>
    {
        IPostReadRepository _postReadRepository;

        public SearchPostQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public Task<SearchPostQueryResponse> Handle(SearchPostQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _postReadRepository.Table.Include(p=>p.CoverImage).Include(p => p.Tags).Include(p=>p.Comments)
                .Where(p=>p.Title.Contains(request.SearchKey) || p.Content.Contains(request.SearchKey)).AsEnumerable();
            var result = query.OrderByDescending(p=> GetScore(p, request.SearchKey)).ToList();
            return Task.FromResult(new SearchPostQueryResponse() { SearchResult = result });

        }
        public int GetScore( Post post, string searckKey)
        {
            int score = 0;
            score += Regex.Matches(post.Title, searckKey, RegexOptions.IgnoreCase).Count * 5;
            score += Regex.Matches(post.Content, searckKey, RegexOptions.IgnoreCase).Count;
            return score;
        }
    }
}
