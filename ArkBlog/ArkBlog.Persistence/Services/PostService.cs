using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Application.Abstracts.Services;
using ArkBlog.Application.Abstracts.Storages.LocalStorage;
using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Identity;
using ArkBlog.Persistence.Repositories.PostRepo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Services
{
    public class PostService : IPostService
    {
        readonly IPostReadRepository _PostReadRepository;
        readonly IPostWriteRepository _PostWriteRepository;
        readonly IAppUserReadRepository _UserReadRepository;

        public PostService(IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository, ILocalStorage localStorage, IAppUserReadRepository userReadRepository = null)
        {
            _PostReadRepository = postReadRepository;
            _PostWriteRepository = postWriteRepository;
            _UserReadRepository = userReadRepository;
        }

        public async Task<bool> PublishAsync(string PostId, string Title, string Content, string userId)
        {
            AppUser author = await _UserReadRepository.GetByIdAsync(userId);
            Post currentPost = await _PostReadRepository.GetByIdAsync(PostId);
            if (author == null || currentPost == null) return false;
            currentPost.Title = Title;
            currentPost.Content = Content;
            currentPost.PublishedAt = DateTime.UtcNow;
            currentPost.IsPublished = true;
            currentPost.ClickCount = 0;
            _PostWriteRepository.Update(currentPost);
            try
            {
                await _PostWriteRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error during SaveChangesAsync: " + ex.Message, ex);
            }
            return true;
        }

        public async Task<(bool, string)> CreateAsync(string userId)
        {
            AppUser author = await _UserReadRepository.GetByIdAsync(userId);
            if (author == null) return (false, "");
            Post post = new Post { Title = "", Content = "", IsPublished = false, AuthorName = author.UserName, Author = author};
            await _PostWriteRepository.AddAsync(post);
            await _PostWriteRepository.SaveChangesAsync();
            return (true, post.Id.ToString());
        }

        public async Task<bool> SaveDraftAsync(String PostId, string Title, string Content, string userId)
        {
            AppUser author = await _UserReadRepository.GetByIdAsync(userId);
            Post currentPost = await _PostReadRepository.GetByIdAsync(PostId);
            if (author == null || currentPost == null) return false;
            currentPost.Title = Title;
            currentPost.Content = Content;
            currentPost.IsPublished = false;
            _PostWriteRepository.Update(currentPost);
            try
            {
                await _PostWriteRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error during SaveChangesAsync: " + ex.Message, ex);
            }
            return true;
        }

        



    }
}
