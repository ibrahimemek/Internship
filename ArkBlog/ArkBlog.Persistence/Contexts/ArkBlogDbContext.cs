using ArkBlog.Domain.Entities;
using ArkBlog.Domain.Entities.Common;
using ArkBlog.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArkBlog.Persistence.Contexts
{
    public class ArkBlogDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ArkBlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }

        public DbSet<PostCoverImageFile> PostCoverImageFiles { get; set; }
        public DbSet<PostGeneralImageFile> PostGeneralImageFiles { get; set; }
        public DbSet<UserProfileImageFile> UserProfileImageFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.ProfileImageFile)
                .WithOne(p=> p.User)
                .HasForeignKey<UserProfileImageFile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.CoverImage)
                .WithOne(c => c.Post)
                .HasForeignKey<PostCoverImageFile>(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Images)
                .WithOne(g => g.Post)
                .HasForeignKey(g => g.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.RelevantPosts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostPostTag", // Join table
                    j => j.HasOne<PostTag>()
                          .WithMany()
                          .HasForeignKey("PostTagId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Post>()
                          .WithMany()
                          .HasForeignKey("PostId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("PostId", "PostTagId");
                        j.ToTable("PostPostTags");
                    });
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
