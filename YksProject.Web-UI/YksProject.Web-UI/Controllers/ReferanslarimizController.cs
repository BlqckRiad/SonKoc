using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using YksProject.Web_UI.Models.Dtos;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReferanslarimizController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReferanslarimizController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult ReferansListeleme()
        {
            return View();
        }
        public IActionResult ReferansEkleme()
        {
            return View();
        }
        [Route("/Referanslarimiz/ReferansGuncelleme/{id}")]
        public IActionResult ReferansGuncelleme()
        {
            return View();
        }


        #region ApiModel


        [HttpGet]
        [Route("/Referanslarimiz/ReferansListeleData")]
        public async Task<IActionResult> ReferansListeleData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/Referanslarimiz";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var referanslar = JsonConvert.DeserializeObject<IEnumerable<ReferanslarimizListViewModel>>(content);
                return Ok(referanslar);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/Referanslarimiz/ReferansSilme")]
        public async Task<IActionResult> ReferansSilme([FromBody] DeleteViewModel deleteDto)
        {
            if (ModelState.IsValid)
            {
                // HttpClient oluştur
                using var client = new HttpClient();

                // API base URL
                var baseUrl = "http://localhost:3798/api/Referanslarimiz";

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
            else
            {
                return BadRequest("Model Uygun Değildir");
            }
        }

        [HttpPost]
        [Route("/Referanslarimiz/ReferansAdd")]
        public async Task<IActionResult> ReferansAdd([FromBody] ReferanslarimizAddViewModel model)
        {

            model.OlusturulmaTarihi = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Referanslarimiz";

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
        [Route("/Referanslarimiz/ReferansGetir/{id}")]
        public async Task<IActionResult> ReferansGetir(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/Referanslarimiz/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var sinavlar = JsonConvert.DeserializeObject<ReferanslarimizListViewModel>(content);
                return Ok(sinavlar);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPut]
        [Route("/Referanslarimiz/ReferansUpdate")]
        public async Task<IActionResult> ReferansUpdate([FromBody] ReferanslarimizUpdateViewModel model)
        {

            
            model.GuncellenmeTarihi = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Referanslarimiz";

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


        #endregion

    }
}
