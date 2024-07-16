using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BolumlerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BolumlerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult BolumListele()
        {
            return View();
        }
        public IActionResult BolumEkle()
        {
            return View();
        }

        [Route("/Bolumler/BolumGuncelle/{id}")]
        public IActionResult BolumGuncelle()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BolumListeleData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/Bolumler";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var bolumler = JsonConvert.DeserializeObject<IEnumerable<BolumListModel>>(content);
                return Ok(bolumler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/Bolumler/BolumSilme")]
        public async Task<IActionResult> BolumSilme([FromBody] DeleteViewModel deleteDto)
        {
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/Bolumler";

            // JSON formatında serialize et
            var content = new StringContent(JsonConvert.SerializeObject(deleteDto), Encoding.UTF8, "application/json");

            // İstek yap
            var response = await client.PostAsync($"{baseUrl}/Silme", content);

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
        [Route("/Bolumler/BolumAdd")]
        public async Task<IActionResult> BolumAdd([FromBody] BolumAddViewModel model)
        {
            model.OlusturulmaTarihi=DateTime.Now;
            
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Bolumler";

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
        [Route("/Bolumler/BolumGetir/{id}")]
        public async Task<IActionResult> BolumGetir(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/Bolumler/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var bolum = JsonConvert.DeserializeObject<BolumAddViewModel>(content);
                return Ok(bolum);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPut]
        [Route("/Bolumler/BolumUpdate")]
        public async Task<IActionResult> BolumUpdate([FromBody] BolumUpdateViewModel model)
        {
            
            model.GuncellenmeTarihi = DateTime.Now;
        
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Bolumler";

                // BolumAddViewModel nesnesini JSON'a dönüştürün
                var jsonContent = JsonConvert.SerializeObject(model);

                // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // HTTP POST isteği yapın ve HttpContent'i kullanın
                var response = await client.PutAsync(apiURL, httpContent);

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
