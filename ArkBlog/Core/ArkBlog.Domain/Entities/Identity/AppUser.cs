using Microsoft.AspNetCore.Identity;

namespace ArkBlog.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public string UserType { get; set; }
        public string NameSurname { get; set; }
        public UserProfileImageFile ProfileImageFile { get; set; }
    }
}
