using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace YksProject.Web_UI.Controllers
{
    [Authorize]
    public class YapilacaklarController : Controller
    {
        [Route("/Yapilacaklar/YapilacaklarListele/{id}")]
        public IActionResult YapilacaklarListele()
        {
            return View();
        }
    }
}
