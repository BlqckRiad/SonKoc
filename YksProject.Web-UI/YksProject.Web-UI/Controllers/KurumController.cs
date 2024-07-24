using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.Dtos.Kurum;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles ="Kurum")]
    public class KurumController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public KurumController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ogrenciler()
        {
            return View();
        }
        public IActionResult OgrenciEkle()
        {
            return View();
        }
        [Route("/Kurum/OgrenciDetay/{id}")]
        public IActionResult OgrenciDetay()
        {
            return View();
        }

        #endregion
        #region ApiModel
        [HttpPost]
        [Route("/Kurum/KurumaAitOgrencileriGetir")]
        public async Task<IActionResult> KurumaAitOgrencileriGetir([FromBody] KurumAndKisiDto model)
        {
            if (ModelState.IsValid)
            {
                // HttpClient oluştur
                var client = new HttpClient();

                // API base URL
                var baseUrl = "https://localhost:44346/api/Kurum/GetUsersForKurum";

                // JSON formatında serialize et
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                // İstek yap
                var response = await client.PostAsync(baseUrl, content);

                // Başarılı mı kontrol et
                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    var ogrs = JsonConvert.DeserializeObject<IEnumerable<KurumGetOgrenci>>(contents);
                    return Ok(ogrs);
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
        [Route("/Kurum/OgrenciAdd")]
        public async Task<IActionResult> OgrenciAdd([FromBody]KurumKisiAddDto model)
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "https://localhost:44346/api/KurumOgrenci/OgrenciEkle";

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
                return BadRequest(response.ReasonPhrase);
            }
            
        }

        [HttpGet]
        [Route("/Kurum/OgrenciGetByid/{id}")]
        public async Task<IActionResult> OgrenciGetByid(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin ve id'yi içine yerleştirin
            var apiURL = $"https://localhost:44346/api/KurumOgrenci/OgrenciGetWithID?id={id}";

            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var kisi = JsonConvert.DeserializeObject<KurumGetOgrenci>(content);
                return Ok(kisi);
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
