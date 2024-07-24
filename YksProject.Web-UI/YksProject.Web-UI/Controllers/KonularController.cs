using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos.Konular;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class KonularController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public KonularController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult KonularList()
        {
            return View();
        }
        public IActionResult KonularAdd()
        {
            return View();
        }
        [Route("/Konular/KonularUpdate/{id}")]
        public IActionResult KonularUpdate()
        {
            return View();
        }
        #endregion
        #region ApiModel
        [HttpGet]
        public async Task<IActionResult> KonularListeleData()
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/Konular";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }

            // Başarılı bir şekilde veri alındıysa JSON olarak döndür
            var content = await response.Content.ReadAsStringAsync();
            var konular = JsonConvert.DeserializeObject<IEnumerable<KonularListDto>>(content);

            var client2 = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL2 = "http://localhost:3798/api/Dersler";

            // HTTP GET isteği yapın
            var response2 = await client2.GetAsync(apiURL2);

            if (!response2.IsSuccessStatusCode)
            {
                return StatusCode((int)response2.StatusCode, response2.ReasonPhrase);
            }

            // Başarılı bir şekilde veri alındıysa JSON olarak döndür
            var content2 = await response2.Content.ReadAsStringAsync();
            var dersler2 = JsonConvert.DeserializeObject<IEnumerable<DerslistViewModel>>(content2);

            // Konuları ve Dersleri birleştir
            var combinedResult = konular.Join(
                dersler2,
                konu => konu.KonuDersID,
                ders => ders.TabloID,
                (konu, ders) =>
                {
                    konu.KonuDersAdi = ders.DersAdi;
                    return konu;
                }
            ).ToList();

            return Ok(combinedResult);
        }

        [HttpPost]
        [Route("/Konular/KonularAddData")]
        public async Task<IActionResult> KonularAddData([FromBody] KonularAddDto model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Konular";

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
        [Route("/Konular/KonularSilmeData")]
        public async Task<IActionResult> KonularSilmeData([FromBody] DeleteViewModel deleteDto)

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

        [HttpGet]
        [Route("/Konular/KonuGetirData/{id}")]
        public async Task<IActionResult> KonuGetirData(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/Konular/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var dersler = JsonConvert.DeserializeObject<KonularListDto>(content);
                return Ok(dersler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpPut]
        [Route("/Konular/KonuGuncelleData")]
        public async Task<IActionResult> KonuGuncelleData([FromBody] KonularUpdateDto model)
        {

            model.GuncellenmeTarihi = DateTime.Now;

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Konular";

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

        [HttpPut]
        [Route("/Konular/KonularUpdateData")]
        public async Task<IActionResult> KonularUpdateData([FromBody] KonularUpdateDto model)
        {

            model.GuncellenmeTarihi = DateTime.Now;

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Konular";

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
        #region HelperModel
        #endregion
    }
}
