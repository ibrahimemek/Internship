using ArkBlog.Application.Abstracts.Hubs;
using ArkBlog.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;


namespace ArkBlog.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IPostHubService, PostHubService>();

            collection.AddSignalR();
        }
    }
}
