using ArkBlog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Domain.Entities
{
    public class PostTag : BaseEntity
    {
        public string TagName { get; set; }
        public ICollection<Post> RelevantPosts { get; set; } = new List<Post>();
    }
}
