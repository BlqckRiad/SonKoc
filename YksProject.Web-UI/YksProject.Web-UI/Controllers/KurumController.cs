using Microsoft.AspNetCore.Mvc;

namespace YksProject.Web_UI.Controllers
{
    public class KurumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
