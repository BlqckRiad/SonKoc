using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos.Admin;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        #region ViewModel
        public IActionResult Index()
        {
      
            return View();
        }

        public IActionResult OgrenciGoruntule()
        {
            return View();
        }
        public IActionResult BildirimList()
        {
            return View();
        }
        public IActionResult BildirimAdd()
        {
            return View();
        }
        #endregion
        #region ApiModel
        /// <summary>
        /// Ogrencilerin Admin Ekranında Listelendiği Fonksiyondur.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<AdminOgrList>>> GetOgrListForAdmin()
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/Kisi";

            try
            {
                // HTTP GET isteği yapın
                var response = await client.GetAsync(apiURL);

                if (response.IsSuccessStatusCode)
                {
                    // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                    var content = await response.Content.ReadAsStringAsync();
                    var ogrList = JsonConvert.DeserializeObject<IEnumerable<AdminOgrList>>(content);
                    return Ok(ogrList);
                }
                else
                {
                    // API'den hata kodu döndüyse hatayı döndür
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                // İstek sırasında bir hata oluşursa hatayı döndür
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("/Admin/BildirimEkle")]
        public async Task<IActionResult> BildirimEkle([FromBody] BildirimAdd model)
        {
            model.OlusturulmaTarihi = DateTime.Now;

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();

                // API URL'sini belirtin
                var apiURL = "http://localhost:3798/api/Bildirimler";

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
        public async Task<IActionResult> BildirimListeleData(int id)


        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin, id parametresini de ekleyin
            var apiURL = $"http://localhost:3798/api/Bildirimler/gonderici/{id}";
            
            // HTTP GET isteği yapın
            var response = await client.GetAsync(apiURL);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde veri alındıysa JSON olarak döndür
                var content = await response.Content.ReadAsStringAsync();
                var bildirimler = JsonConvert.DeserializeObject<IEnumerable<BildirimList>>(content);
                return Ok(bildirimler);
            }
            else
            {
                // API'den hata kodu döndüyse hatayı döndür
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        [Route("/Admin/BildirimSilme")]
        public async Task<IActionResult> BildirimSilme([FromBody] DeleteViewModel deleteDto)
        {
            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/Bildirimler";

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

        #endregion
        #region HelperModel

        /// <summary>
        /// Bildiirm Gönderme Fonksiyonudur.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Admin/SenNotifToFirebase")]
        public object SenNotifToFirebase([FromBody] BildirimAdd model)
        {
            string authSecret = "dYRSXRFU30Wxm5vdoYTHbRc2uI2Nusm1BsmFVmER";
            string basePath = "https://sonkocnotifdb-default-rtdb.firebaseio.com/";
          

            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath,
            };
            client = new FireSharp.FirebaseClient(config);

            object response = null;

            if (client != null && !string.IsNullOrEmpty(basePath) && !string.IsNullOrEmpty(authSecret))
            {
                var data = new BildirimList
                {
                    BildirimAciklamasi = model.BildirimAciklamasi,
                    BildirimBasligi = model.BildirimBasligi,
                    AliciKisiID = model.AliciKisiID,
                    OlusturanKisiID = model.GonderenKisiID,
                    GonderenKisiID = model.GonderenKisiID,
                    OlusturulmaTarihi = DateTime.Now,
                    BildirimAliciOkuduMu = false
                };
                data.SilindiMi = false;
                

                // Veriyi "doc/" yoluna ekle ve benzersiz anahtar oluştur
                response = client.Push("Bildirimler/", data);
            }

            return response;
        }
       
        /// <summary>
        /// Alınan Bildirimlerin Listelendiği Fonksiyondur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Admin/GetNotificationsByAliciKisiID/{id}")]
        public List<BildirimList> GetNotificationsByAliciKisiID(int id) // aliciKisiID yerine id
        {
            string authSecret = "dYRSXRFU30Wxm5vdoYTHbRc2uI2Nusm1BsmFVmER";
            string basePath = "https://sonkocnotifdb-default-rtdb.firebaseio.com/";

            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath,
            };
            client = new FireSharp.FirebaseClient(config);

            List<BildirimList> notifications = new List<BildirimList>();

            if (client != null && !string.IsNullOrEmpty(basePath) && !string.IsNullOrEmpty(authSecret))
            {
                // Veritabanındaki tüm bildirimleri çek
                FirebaseResponse response = client.Get("Bildirimler/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                if(data == null)
                {
                    return null;
                }
                foreach (var item in data)
                {
                    var firebaseKey = ((JProperty)item).Name; // Firebase'den gelen key değeri
                    var notification = JsonConvert.DeserializeObject<BildirimList>(((JProperty)item).Value.ToString());
                    notification.TabloID = firebaseKey; // Firebase key'i BildirimList sınıfına atanıyor

                    // AliciKisiID'ye göre filtreleme yap
                    if ((notification.AliciKisiID == id || notification.AliciKisiID == 0)&&notification.SilindiMi==false)
                    {
                        notifications.Add(notification);
                    }
                }
            }

            return notifications;
        }

        /// <summary>
        /// Gonderilen bildirimlerin listelendiği fonksiyondur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Admin/GetNotificationsByGondericiKisiID/{id}")]
        public List<BildirimList> GetNotificationsByGondericiKisiID(int id) // aliciKisiID yerine id
        {
            string authSecret = "dYRSXRFU30Wxm5vdoYTHbRc2uI2Nusm1BsmFVmER";
            string basePath = "https://sonkocnotifdb-default-rtdb.firebaseio.com/";

            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath,
            };
            client = new FireSharp.FirebaseClient(config);

            List<BildirimList> notifications = new List<BildirimList>();

            if (client != null && !string.IsNullOrEmpty(basePath) && !string.IsNullOrEmpty(authSecret))
            {
                // Veritabanındaki tüm bildirimleri çek
                FirebaseResponse response = client.Get("Bildirimler/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

                foreach (var item in data)
                {
                    var firebaseKey = ((JProperty)item).Name; // Firebase'den gelen key değeri
                    var notification = JsonConvert.DeserializeObject<BildirimList>(((JProperty)item).Value.ToString());
                    notification.TabloID = firebaseKey; // Firebase key'i BildirimList sınıfına atanıyor

                    // AliciKisiID'ye göre filtreleme yap
                    if ((notification.GonderenKisiID == id) && notification.SilindiMi==false)
                    {
                        notifications.Add(notification);
                    }
                }
            }

            return notifications;
        }
        /// <summary>
        /// Bildirim Silme Fonksiyonudur.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Admin/DeleteNotification")]
        public IActionResult DeleteNotification([FromBody] DeleteViewModelForNotification model)
        {
            string authSecret = "dYRSXRFU30Wxm5vdoYTHbRc2uI2Nusm1BsmFVmER";
            string basePath = "https://sonkocnotifdb-default-rtdb.firebaseio.com/";

            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath,
            };
            client = new FireSharp.FirebaseClient(config);

            if (client != null && !string.IsNullOrEmpty(basePath) && !string.IsNullOrEmpty(authSecret))
            {
                // Önce mevcut veriyi al
                FirebaseResponse response = client.Get("Bildirimler/" + model.TabloID);
                var notification = JsonConvert.DeserializeObject<BildirimList>(response.Body);

                if (notification != null)
                {
                    notification.SilinmeTarihi = DateTime.Now;
                    notification.SilenKisiID = model.SilenKisiID;
                    notification.SilindiMi = true;
                    

                    // Firebase'deki ilgili yolu güncelle
                    var updateResponse = client.Update("Bildirimler/" + model.TabloID, notification);
                    if (updateResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Ok(new { message = "Bildirim başarıyla Silindi." });

                    }
                    else
                    {
                        return StatusCode((int)updateResponse.StatusCode, "Silinme sırasında bir hata oluştu.");
                    }
                }
                else
                {
                    return NotFound("Bildirim bulunamadı.");
                }
            }

            return StatusCode(500, "Firebase bağlantısı kurulamadı.");
        }
        /// <summary>
        /// Id bazlı bildirim getirmeye yarayan fonksiyondur.
        /// </summary>
        /// <param name="notifid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Admin/GetNotificationWithID/{id}")]
        public IActionResult GetNotificationWithID(string notifid)
        {
            string authSecret = "dYRSXRFU30Wxm5vdoYTHbRc2uI2Nusm1BsmFVmER";
            string basePath = "https://sonkocnotifdb-default-rtdb.firebaseio.com/";

            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath,
            };
            client = new FireSharp.FirebaseClient(config);

            if (client != null && !string.IsNullOrEmpty(basePath) && !string.IsNullOrEmpty(authSecret))
            {
                // Önce mevcut veriyi al
                FirebaseResponse response = client.Get("Bildirimler/" + notifid);
                var notification = JsonConvert.DeserializeObject<BildirimList>(response.Body);
               return Ok(notification);
            }
            return BadRequest("Database'e erişim gerçekleşmedi.");
        }
        #endregion
    }
}


