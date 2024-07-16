using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DerslerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public DerslerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult DersListele()
        {
            return View();
        }
        public IActionResult DersEkle()
        {
            return View();
        }

        [Route("/Dersler/DersGuncelle/{id}")]
        public IActionResult DersGuncelle()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DersListeleData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/Dersler";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var dersler = JsonConvert.DeserializeObject<IEnumerable<DerslistViewModel>>(content);
                return Ok(dersler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpPost]
        [Route("/Dersler/DersAdd")]
        public async Task<IActionResult> DersAdd([FromBody] DerslerAddViewModel model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Dersler";

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


        
        [HttpPost]
        [Route("/Dersler/DersSilme")]
        public async Task<IActionResult> DersSilme([FromBody] DeleteViewModel deleteDto)

        {
          
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/Dersler";

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

        [HttpPut]
        [Route("/Dersler/DersUpdate")]
        public async Task<IActionResult> DersUpdate([FromBody] DersUpdateViewModel model)
        {
            
            model.GuncellenmeTarihi = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Dersler";

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


        [HttpGet]
        [Route("/Dersler/DersGetir/{id}")]
        public async Task<IActionResult> DersGetir(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/Dersler/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var dersler = JsonConvert.DeserializeObject<DerslistViewModel>(content);
                return Ok(dersler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
