using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace YksProject.Web_UI.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index() {
        if (User.Identity.IsAuthenticated)
        { 
                var roleClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            if (roleClaim != null)
            {
                var role = roleClaim.Value;
                if (role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                 else if (role == "User")
                 {
                  return RedirectToAction("Index", "User");
                  }
                    else if (role == "Kurum")
                    {
                        return RedirectToAction("Index", "Kurum");
                    }

                }
        }

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
      
    }
}
