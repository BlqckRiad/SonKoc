using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using YksProject.Web_UI.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using YksProject.Web_UI.Models.Dtos;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SinavController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SinavController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult SinavListeleme()
        {
            return View();
        }
        public IActionResult SinavEkleme()
        {
            return View();
        }
        [Route("/Sinav/SinavGuncelleme/{id}")]
        public IActionResult SinavGuncelleme()
        {
            return View();
        }

        [HttpGet]
        [Route("/Sinav/SinavListeleData")]
        public async Task<IActionResult> SinavListeleData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "https://localhost:44340/Sinav/KisiGenelSinavlariGetir";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var sinavlar = JsonConvert.DeserializeObject<IEnumerable<SinavListViewModel>>(content);
                return Ok(sinavlar);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/Sinav/SinavSilme")]
        public async Task<IActionResult> SinavSilme([FromBody] DeleteViewModel deleteDto)
        {
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "https://localhost:44340/Sinav/SinavSil";

            // JSON formatında serialize et
            var content = new StringContent(JsonConvert.SerializeObject(deleteDto), Encoding.UTF8, "application/json");

            // İstek yap
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
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
        [HttpPost]
        [Route("/Sinavlar/SinavlarAdd")]
        public async Task<IActionResult> SinavlarAdd([FromBody] SinavAddViewModel model)
        {
            model.OlusturulmaTarihi = DateTime.Now;

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "https://localhost:44340/Sinav/SinavEkle";

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
        [Route("/Sinavlar/SinavGetir/{id}")]
        public async Task<IActionResult> SinavGetir(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"https://localhost:44340/Sinav/SinavGetWithid/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var sinavlar = JsonConvert.DeserializeObject<SinavListViewModel>(content);
                return Ok(sinavlar);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPut]
        [Route("/Sinavlar/SinavUpdate")]
        public async Task<IActionResult> SinavUpdate([FromBody] SinavUpdateViewModel model)
        {

          

            model.GuncellenmeTarihi = DateTime.Now;
       

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "https://localhost:44340/Sinav/SinavGuncelle";

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


    }
}
