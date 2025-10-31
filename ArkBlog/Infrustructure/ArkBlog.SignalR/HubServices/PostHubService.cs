using ArkBlog.Application.Abstracts.Hubs;
using ArkBlog.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.SignalR.HubServices
{
    public class PostHubService : IPostHubService
    {
        readonly IHubContext<PostHub> _hubContext;

        public PostHubService(IHubContext<PostHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task PostAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.PostAddedMessage, message);

        }
    }
}
