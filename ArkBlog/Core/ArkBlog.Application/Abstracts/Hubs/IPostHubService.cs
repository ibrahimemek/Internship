using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Abstracts.Hubs
{
    public interface IPostHubService
    {
        Task PostAddedMessageAsync(string message);
    }
}
