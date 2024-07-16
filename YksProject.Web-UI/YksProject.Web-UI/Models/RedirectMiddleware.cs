using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace YksProject.Web_UI.Models
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                // Kullanıcı kimlik doğrulaması yapılmışsa
                if (context.User.IsInRole("Admin"))
                {
                    // Eğer kullanıcı Admin rolüne sahipse Admin/Index'e yönlendir
                    context.Response.Redirect("/Admin/Index");
                    return;
                }
                else
                {
                    // Diğer durumlarda varsayılan olarak Home/Index'e yönlendir
                    context.Response.Redirect("/Home/Index");
                    return;
                }
            }

            // Kimlik doğrulaması yapılmamışsa isteği işleme devam et
            await _next(context);
        }
    }
}
