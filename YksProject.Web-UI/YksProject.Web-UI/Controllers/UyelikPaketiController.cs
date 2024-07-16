using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.ViewModel;
using YksProject.Web_UI.Models.Dtos.UyelikPaketleri;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UyelikPaketiController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public UyelikPaketiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult UyelikPaketiList()
        {
            return View();
        }
        [Route("/UyelikPaketi/UPaketEkleme")]
        public IActionResult UPaketEkleme()
        {
            return View();
        }
        [Route("/UyelikPaketi/UyelikPaketiGuncelleme/{id}")]
        public IActionResult UyelikPaketiGuncelleme()
        {
            return View();
        }

        [HttpGet]
        [Route("/UyelikPaketi/UyelikPaketiListData")]
        public async Task<IActionResult> UyelikPaketiListData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/UyelikPaketleri";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var paketler = JsonConvert.DeserializeObject<IEnumerable<UyelikPaketiListDto>>(content);
                return Ok(paketler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/UyelikPaketi/UyelikPaketiSilme")]
        public async Task<IActionResult> UyelikPaketiSilme([FromBody] DeleteViewModel deleteDto)
        {

            

            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/UyelikPaketleri";

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
        [Route("/UyelikPaketi/UyelikPaketiEkle")]
        public async Task<IActionResult> UyelikPaketiEkle([FromBody] UyelikPaketiAddDto model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
         

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/UyelikPaketleri";

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
        [Route("/UyelikPaketi/UyelikPaketiGetir/{id}")]
        public async Task<IActionResult> UyelikPaketiGetir(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/UyelikPaketleri/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var sinavlar = JsonConvert.DeserializeObject<UyelikPaketiListDto>(content);
                return Ok(sinavlar);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPut]
        [Route("/UyelikPaketi/UyelikPaketiUpdate")]
        public async Task<IActionResult> UyelikPaketiUpdate([FromBody] UyelikPaketiUpdateDto model)
        {

            
            model.GuncellenmeTarihi = DateTime.Now;
         

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/UyelikPaketleri";

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
