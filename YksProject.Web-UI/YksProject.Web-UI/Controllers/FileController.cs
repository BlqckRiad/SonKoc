using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    public class FileController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            var tabloIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "TabloID");
            var tabloIdValue = int.Parse(tabloIdClaim.Value);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var model = new MedyaKutuphanesiAddDto
            {
                MedyaAdi = fileName,
                OlusturulmaTarihi = DateTime.Now,
                OlusturanKisiID = tabloIdValue,
                MedyaUrl = path
            };


            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:3798/api/Files", model);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MedyaKutuphanesiList>(content);

            return Ok(result);
        }

        [HttpGet]
        [Route("/File/DeleteFile/{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var tabloIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "TabloID");
            var tabloIdValue = int.Parse(tabloIdClaim.Value);

            var deleteDto = new DeleteDto
            {
                TabloID = id,
                SilenKisiID = tabloIdValue
            };

            // HttpClient oluştur
            using var client = new HttpClient();

            // API base URL
            var baseUrl = "http://localhost:3798/api/Files";

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
        [Route("/File/DeleteFileWithUrl/{url}")]
        public async Task<IActionResult> DeleteFileWithUrl(string url)
        {
            using var client = new HttpClient();
            var baseUrl = "http://localhost:3798/api/Files";

            // HTTP DELETE isteği gönder
            var response = await client.DeleteAsync($"{baseUrl}/DeleteMedyaWithUrl?url={url}");

            // Başarılı mı kontrol et
            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }


    }
}
