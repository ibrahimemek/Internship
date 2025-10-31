using ArkBlog.Application.Abstracts.Repositories.CommentRepo;
using ArkBlog.Application.Abstracts.Repositories.EndpointRepo;
using ArkBlog.Application.Abstracts.Repositories.FileRepo;
using ArkBlog.Application.Abstracts.Repositories.MenuRepo;
using ArkBlog.Application.Abstracts.Repositories.PostCoverImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.PostGeneralImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using ArkBlog.Application.Abstracts.Repositories.UserProfileImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.UserRepo;
using ArkBlog.Application.Abstracts.Services;
using ArkBlog.Domain.Entities.Identity;
using ArkBlog.Persistence.Contexts;
using ArkBlog.Persistence.Repositories.CommentRepo;
using ArkBlog.Persistence.Repositories.EndpointRepo;
using ArkBlog.Persistence.Repositories.FileRepo;
using ArkBlog.Persistence.Repositories.MenuRepo;
using ArkBlog.Persistence.Repositories.PostCoverImageFileRepo;
using ArkBlog.Persistence.Repositories.PostGeneralImageFileRepo;
using ArkBlog.Persistence.Repositories.PostRepo;
using ArkBlog.Persistence.Repositories.TagRepo;
using ArkBlog.Persistence.Repositories.UserProfileImageFileRepo;
using ArkBlog.Persistence.Repositories.UserRepo;
using ArkBlog.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArkBlog.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ArkBlogDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Scoped);
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ArkBlogDbContext>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<ITagWriteRepository, TagWriteRepository>();
            services.AddScoped<ITagReadRepository, TagReadRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IPostCoverImageFileReadRepository, PostCoverImageFileReadRepository>();
            services.AddScoped<IPostCoverImageFileWriteRepository, PostCoverImageFileWriteRepository>();
            services.AddScoped<IPostGeneralImageFileReadRepository, PostGeneralImageFileReadRepository>();
            services.AddScoped<IPostGeneralImageFileWriteRepository, PostGeneralImageFileWriteRepository>();
            services.AddScoped<IUserProfileImageFileReadRepository, UserProfileImageFileReadRepository>();
            services.AddScoped<IUserProfileImageFileWriteRepository, UserProfileImageFileWriteRepository>();
            services.AddScoped<IAppUserReadRepository, AppUserReadRepository>();
            services.AddScoped<IAppUserWriteRepository, AppUserWriteRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            




        }
    }
}
