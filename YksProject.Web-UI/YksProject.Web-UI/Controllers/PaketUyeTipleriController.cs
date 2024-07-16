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
using YksProject.Web_UI.Models.Dtos.PaketUyeTipleri;
using Microsoft.AspNetCore.Authorization;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PaketUyeTipleriController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PaketUyeTipleriController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult PaketUyeTipleriList()
        {
            return View();
        }
        public IActionResult PaketUyeTipleriAdd()
        {
            return View();
        }
        [Route("/PaketUyeTipleri/PaketUyeTipleriUpdate/{id}")]
        public IActionResult PaketUyeTipleriUpdate()
        {
            return View();
        }
        #endregion

        #region ApiModel
        [HttpGet]
        public async Task<IActionResult> PaketUyeTipleriListeleData()
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/PaketUyeTipleri";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var dersler = JsonConvert.DeserializeObject<IEnumerable<PaketUyeTipleriList>>(content);
                return Ok(dersler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpPost]
        [Route("/PaketUyeTipleri/PaketUyeTipleriAddData")]
        public async Task<IActionResult> PaketUyeTipleriAddData([FromBody] PaketUyeTipleriAdd model)
        {
            model.OlusturulmaTarihi = DateTime.Now;

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/PaketUyeTipleri";

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
        [Route("/PaketUyeTipleri/PaketUyeTipleriDeleteData")]
        public async Task<IActionResult> PaketUyeTipleriDeleteData([FromBody] DeleteViewModel deleteDto)
        {
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/PaketUyeTipleri";

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
        [Route("/PaketUyeTipleri/PaketUyeTipleriUpdateData")]
        public async Task<IActionResult> PaketUyeTipleriUpdateData([FromBody] PaketUyeTipleriUpdate model)
        {
            
            model.GuncellenmeTarihi = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/PaketUyeTipleri";

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
        [Route("/PaketUyeTipleri/PaketUyeTipleriGetData/{id}")]
        public async Task<IActionResult> PaketUyeTipleriGetData(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/PaketUyeTipleri/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var dersler = JsonConvert.DeserializeObject<PaketUyeTipleriList>(content);
                return Ok(dersler);
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
