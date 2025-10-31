using ArkBlog.Domain.Entities.Common;
using ArkBlog.Domain.Entities.Identity;

namespace ArkBlog.Domain.Entities
{
    public class Post : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public AppUser Author {  get; set; }

        public ICollection<PostTag> Tags { get; set; } = new List<PostTag>();
        public ICollection<PostGeneralImageFile>? Images { get; set; }
        public PostCoverImageFile? CoverImage { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();



        public string Title { get; set; }
        public string Content { get; set; }
        public string? AuthorName { get; set; }
        public int ClickCount { get; set; }
        public bool IsPublished { get; set; }
        public bool IsEditorPick { get; set; }

        public DateTime? PublishedAt { get; set; }
       

       

    }
}