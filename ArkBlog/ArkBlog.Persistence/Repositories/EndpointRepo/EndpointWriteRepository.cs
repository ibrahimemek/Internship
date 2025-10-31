using ArkBlog.Application.Abstracts.Repositories.EndpointRepo;
using ArkBlog.Domain.Entities;
using ArkBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Persistence.Repositories.EndpointRepo
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ArkBlogDbContext context) : base(context)
        {
        }
    }
}
