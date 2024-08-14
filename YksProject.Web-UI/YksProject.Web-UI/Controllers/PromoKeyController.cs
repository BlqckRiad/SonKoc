using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.Dtos.PaketUyeTipleri;
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
        [HttpPost]
        [Route("/PromoKey/PromoKeyAddData")]
        public async Task<IActionResult> PromoKeyAddData([FromBody]PromoKeyAddDto model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al

            var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/PromoKey/PromoKeyAdd";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);
            // PromoKeyAddDto nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

                // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // HTTP POST isteği yapın ve HttpContent'i kullanın
                var response = await client.PostAsync(apiURL, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            
           
        }
        [HttpPost]
        [Route("/PromoKey/PromoKeyDelete")]
        public async Task<IActionResult> PromoKeyDelete([FromBody] DeleteDto model)
        {
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/PromoKey/DeletePromoKey";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);
            // PromoKeyAddDto nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

            // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // HTTP POST isteği yapın ve HttpContent'i kullanın
            var response = await client.PostAsync(apiURL, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }
        [HttpGet]
        [Route("/PromoKey/GetPromoKeyWithID/{id}")]
        public async Task<IActionResult> GetPromoKeyWithID(int id)
        {
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = $"http://localhost:3798/api/PromoKey/GetPromoKeyWithID?id={id}";
            // HTTP GET isteği yapın ve Authorization başlığına token'ı ekleyin
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);

            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                // Eğer tek bir nesne döndürülüyorsa:
                var key = JsonConvert.DeserializeObject<PromoKeyListDto>(content);
                return Ok(key);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/PromoKey/PromoKeyUpdateData")]
        public async Task<IActionResult> PromoKeyUpdateData([FromBody] PromoKeyUpdateDto model)
        {
            model.GuncellenmeTarihi = DateTime.Now;
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/PromoKey/PromoKeyUpdate";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);
            // PromoKeyAddDto nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

            // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // HTTP POST isteği yapın ve HttpContent'i kullanın
            var response = await client.PostAsync(apiURL, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }


        }
        #endregion
        #region HelperModel
        #endregion
    }
}
