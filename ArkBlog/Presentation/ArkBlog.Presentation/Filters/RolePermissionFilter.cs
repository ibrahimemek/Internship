using ArkBlog.Application.Abstracts.Services;
using ArkBlog.Application.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ArkBlog.Presentation.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        private readonly IAppUserService _userService;

        public RolePermissionFilter(IAppUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var allowAnonymous = descriptor?.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            if (allowAnonymous != null)
            {
                await next(); // Token isteme
                return;
            }

            // 1️⃣ Kullanıcı login olmuş mu kontrol et
            Console.WriteLine($"🔍 User Identity: {context.HttpContext.User?.Identity?.Name}");
            Console.WriteLine($"🔍 Is Authenticated: {context.HttpContext.User?.Identity?.IsAuthenticated}");
            Console.WriteLine($"🔍 Authentication Type: {context.HttpContext.User?.Identity?.AuthenticationType}");
            Console.WriteLine($"🔍 Claims Count: {context.HttpContext.User?.Claims?.Count() ?? 0}");
            
            if (context.HttpContext.User?.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                Console.WriteLine("❌ User not authenticated - returning Unauthorized");
                context.Result = new UnauthorizedResult();
                return;
            }

            var username = context.HttpContext.User.Identity.Name;

            // 2️⃣ Eğer kullanıcı "emekibr" ise (senin bypass kullanıcı) direk devam et
            if (username == "emekibr")
            {
                await next();
                return;
            }

            // 3️⃣ Endpoint üzerindeki AuthorizeDefinition attribute'unu bul
            var attribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

            if (attribute == null)
            {
                // Attribute yoksa → filtre bu action için çalışmasın
                await next();
                return;
            }

            // 4️⃣ HTTP method bilgisini al (GET, POST vs.)
            var httpAttribute = descriptor.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;
            var httpMethod = httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get;

            // 5️⃣ Unique permission kodunu oluştur
            var code = $"{httpMethod}.{attribute.ActionType}.{attribute.Definition.Replace(" ", "")}";

            // 6️⃣ Kullanıcının yetkisi var mı kontrol et
            var hasRole = await _userService.HasRolePermissionToEndpointAsync(username, code);

            if (!hasRole)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // 7️⃣ Yetkiliyse devam et
            await next();
        }
    }
}
