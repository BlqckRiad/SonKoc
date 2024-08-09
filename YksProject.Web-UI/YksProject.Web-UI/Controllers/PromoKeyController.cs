using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos.PromoKey;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PromoKeyController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PromoKeyController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult PromoKeyList()
        {
            return View();
        }
        public IActionResult PromoKeyAdd()
        {
            return View();
        }
        [Route("/PromoKey/PromoKeyUpdate/{id}")]
        public IActionResult PromoKeyUpdate()
        {
            return View();
        }
        #endregion
        #region ApiModel
        [HttpGet]
        public async Task<IActionResult> PromoKeysListData()
        {
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/PromoKey/GetAllPromoKeys";

            // HTTP GET isteği yapın ve Authorization başlığına token'ı ekleyin
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);

            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var keys = JsonConvert.DeserializeObject<IEnumerable<PromoKeyListDto>>(content);
                return Ok(keys);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }

        #endregion
        #region HelperModel
        #endregion
    }
}
