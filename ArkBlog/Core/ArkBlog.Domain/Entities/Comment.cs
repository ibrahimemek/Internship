using ArkBlog.Domain.Entities.Common;
using ArkBlog.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Context {  get; set; }
        public Post Post { get; set; }
        public Guid PostId { get; set; }
        public AppUser Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
