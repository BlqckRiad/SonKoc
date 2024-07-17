using Microsoft.AspNetCore.Mvc;

namespace YksProject.Web_UI.Controllers
{
    public class KurumController : Controller
    {
        #region ViewModel
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ogrenciler()
        {
            return View();
        }
        #endregion
        #region ApiModel

        #endregion

        #region HelperModel

        #endregion
    }
}
