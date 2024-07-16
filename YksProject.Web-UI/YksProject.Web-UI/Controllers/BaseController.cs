using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace YksProject.Web_UI.Controllers
{
    public class BaseController : Controller
    {
         
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                var kisiimage = User.Claims.FirstOrDefault(c => c.Type == "KisiImageUrl")?.Value;
                ViewBag.KisiImageUrl = kisiimage;


                ViewBag.UserName = userName;
            }
        }
    }
}
