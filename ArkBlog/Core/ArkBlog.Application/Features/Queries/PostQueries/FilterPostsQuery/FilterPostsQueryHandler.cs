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

namespace ArkBlog.Application.Features.Queries.PostQueries.FilterPostsQuery
{
    public class FilterPostsQueryHandler : IRequestHandler<FilterPostsQueryRequest, FilterPostsQueryResponse>
    {
        IPostReadRepository _postReadRepository;
        IAppUserReadRepository _userReadRepository;

        public FilterPostsQueryHandler(IPostReadRepository postReadRepository, IAppUserReadRepository userReadRepository)
        {
            _postReadRepository = postReadRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<FilterPostsQueryResponse> Handle(FilterPostsQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser author = null;
            if (request.AuthorId != null)
                author = await _userReadRepository.GetByIdAsync(request.AuthorId);
            
            List<Post> updatedPosts = new List<Post>();
            if (request.PostIds == null)
            {
                List <Post> posts = _postReadRepository.Table.Include(p=> p.CoverImage).Include(p => p.Tags).Include(p=>p.Comments).ToList();
                foreach (Post current in posts)
                {
                    if (request.TagName == null || current.Tags.Any(pt => pt.TagName == request.TagName))
                        if (author == null || current.Author == author)
                            updatedPosts.Add(current);

                }

            }
            else
            {
                foreach (var id in request.PostIds)
                {
                    Post current = await _postReadRepository.Table.Include(p => p.CoverImage).Include(p=>p.Tags).Include(p => p.Comments).FirstOrDefaultAsync(p=> p.Id.ToString() == id);
                    if (request.TagName == null || current.Tags.Any(pt => pt.TagName == request.TagName))
                        if (author == null || current.Author == author)
                            updatedPosts.Add(current);

                }
            }
            if (request.IsPublished != null)
                updatedPosts.RemoveAll(post => request.IsPublished != post.IsPublished);
            

            if (request.Selection != null)
            {
                switch (request.Selection)
                {
                    case ("Top"):
                    case ("top"):
                        updatedPosts = updatedPosts.OrderByDescending(p => p.ClickCount).ToList();
                        break;
                    case ("recent"):
                    case ("Recent"):
                        updatedPosts = updatedPosts.OrderByDescending(p => p.PublishedAt).ToList();
                        break;
                    case ("editor's picks"):
                    case ("Editor's Picks"):
                        updatedPosts.RemoveAll(p => p.IsEditorPick != true);
                        break;
                    default:
                        break;
                }
            }
            if (request.Count != null && request.Count < updatedPosts.Count)
                updatedPosts.GetRange(0, (int) request.Count);
            return new FilterPostsQueryResponse() { Posts = updatedPosts };
                
            
        }
    }
}
