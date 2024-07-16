using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using YksProject.Web_UI.Models.Dtos.SinavTipleri;
using YksProject.Web_UI.Models.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using YksProject.Web_UI.Models.Dtos.Konular;

namespace YksProject.Web_UI.Controllers
{
    public class SinavTipleriController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SinavTipleriController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult SinavTipiListele()
        {
            return View();  
        }
        public IActionResult SinavTipiEkle()
        {
            return View();
        }
        [Route("/SinavTipleri/SinavTipiGuncelle/{id}")]
        public IActionResult SinavTipiGuncelle()
        {
            return View();
        }
        #endregion
        #region ApiModel
        
        [HttpPost]
        [Route("/SinavTipleri/SinavTipleriAdd")]
        public async Task<IActionResult> SinavTipleriAdd([FromBody] SinavTipiAddDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "https://localhost:44340/SinavTipleri/SinavTipiEkle";

                // BolumAddViewModel nesnesini JSON'a dönüştürün
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
            else
            {

                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        public async Task<IActionResult> SinavTipleriListeleData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "https://localhost:44340/SinavTipleri/SinavTipleriGetir";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var sinavtipleri = JsonConvert.DeserializeObject<IEnumerable<SinavTipleriListDto>>(content);
                return Ok(sinavtipleri);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/SinavTipleri/SinavTipiSilme")]
        public async Task<IActionResult> SinavTipiSilme([FromBody] DeleteViewModel deleteDto)
        {
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "https://localhost:44340/SinavTipleri/SinavTipiSil"; // Ensure this URL is correct

            // JSON formatında serialize et
            var content = new StringContent(JsonConvert.SerializeObject(deleteDto), Encoding.UTF8, "application/json");

           
                var response = await client.PostAsync(baseUrl, content);

                // Başarılı mı kontrol et
                if (response.IsSuccessStatusCode)
                {
                    // Başarılı ise işlem tamamlandı
                    return Ok(response);
                }
                else
                {
                    // Başarısız ise uygun hata mesajını döndür
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }
            
        }

        [HttpGet]
        [Route("/SinavTipleri/SinavTipleriGetirData/{id}")]
        public async Task<IActionResult> SinavTipleriGetirData(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"https://localhost:44340/SinavTipleri/SinavTipleriGetir/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var sinavtipleri = JsonConvert.DeserializeObject<SinavTipleriListDto>(content);
                return Ok(sinavtipleri);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpPut]
        [Route("/SinavTipleri/SinavTipiGuncelleData")]
        public async Task<IActionResult> SinavTipiGuncelleData([FromBody] SinavTipleriUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "https://localhost:44340/SinavTipleri/SinavTipiGuncelle";

                // BolumAddViewModel nesnesini JSON'a dönüştürün
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
            else
            {

                return BadRequest(ModelState);
            }
        }

        #endregion
        #region HelperModel
        #endregion
    }
}
