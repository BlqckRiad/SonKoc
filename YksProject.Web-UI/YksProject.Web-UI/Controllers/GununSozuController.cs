using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using YksProject.Web_UI.Models.Dtos.PromoKey;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.Dtos.GununSozu;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class GununSozuController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public GununSozuController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult GununSozuList()
        {
            return View();
        }
        public IActionResult GununSozuAdd()
        {
            return View();
        }
        [Route("/GununSozu/GununSozuUpdate/{id}")]
        public IActionResult GununSozuUpdate()
        {
            return View();
        }
        #endregion
        #region ApiModel
        [HttpGet]
        public async Task<IActionResult> GununSozuListData()
        {
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/GununSozu/Get";

            // HTTP GET isteği yapın ve Authorization başlığına token'ı ekleyin
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);

            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var keys = JsonConvert.DeserializeObject<IEnumerable<GununSozuListDto>>(content);
                return Ok(keys);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/GununSozu/GununSozuAddData")]
        public async Task<IActionResult> GununSozuAddData([FromBody] GununSozuAddDto model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/GununSozu/Add";
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
        [Route("/GununSozu/GununSozuDelete")]
        public async Task<IActionResult> GununSozuDelete([FromBody] DeleteDto model)
        {
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/GununSozu/Delete";
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
        [Route("/GununSozu/GetGununSozuWithID/{id}")]
        public async Task<IActionResult> GetGununSozuWithID(int id)
        {
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al
            var client = _clientFactory.CreateClient();
        
            // API URL'sini belirtin
            var apiURL = $"http://localhost:3798/api/GununSozu/GetWithID?id={id}";
            // HTTP GET isteği yapın ve Authorization başlığına token'ı ekleyin
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Split(' ')[1]);

            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                // Eğer tek bir nesne döndürülüyorsa:
                var key = JsonConvert.DeserializeObject<GununSozuListDto>(content);
                return Ok(key);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/GununSozu/GununSozuUpdateData")]
        public async Task<IActionResult> GununSozuUpdateData([FromBody] GununSozuUpdateDto model)
        {
            model.GuncellenmeTarihi = DateTime.Now;
            var token = Request.Headers["Authorization"].ToString(); // İstekten Authorization başlığını al

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/GununSozu/GununSozuUpdate";
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
