using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Domain.Entities
{
    public class PostGeneralImageFile : File
    {
        public Post Post { get; set; }
        public Guid PostId { get; set; }
    }
}
