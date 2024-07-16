using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos.HomePost;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    public class HomePostController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomePostController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult HomePostList()
        {
            return View();
        }
        public IActionResult HomePostAdd()
        {
            return View(); 
        }
        [Route("/HomePost/HomePostUpdate/{id}")]
        public IActionResult HomePostUpdate()
        {
            return View();
        }
        #endregion
        #region ApiModel
        [HttpGet]
        public async Task<IActionResult> HomePostListData()
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini ve yolu belirtin
            var apiURL = "http://localhost:3798/api/HomePost/ForAdmin";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var homepost = JsonConvert.DeserializeObject<IEnumerable<HomePostListDto>>(content);
                return Ok(homepost);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/HomePost/HomePostAddData")]
        public async Task<IActionResult> HomePostAddData([FromBody] HomePostAddDto model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            model.PostGorulmeSayisi = 0;
            model.PostTiklanmaSayisi = 0;
            model.PostYayindaMi = false;
            
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/HomePost";

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
        [Route("/HomePost/HomePostSilme")]
        public async Task<IActionResult> HomePostSilme([FromBody] DeleteViewModel deleteDto)
        {
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/HomePost";

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
        [Route("/HomePost/PostGetir/{id}")]
        public async Task<IActionResult> PostGetir(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"http://localhost:3798/api/HomePost/{id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<HomePostListDto>(content);
                return Ok(post);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }


        [HttpPut]
        [Route("/HomePost/HomePostUpdate")]
        public async Task<IActionResult> HomePostUpdate([FromBody] HomePostUpdateDto model)
        {

            model.GuncellenmeTarihi = DateTime.Now;

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/HomePost";

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

