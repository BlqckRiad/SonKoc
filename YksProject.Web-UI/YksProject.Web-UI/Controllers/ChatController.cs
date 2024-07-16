using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos;
using YksProject.Web_UI.Models.Dtos.Message;
using YksProject.Web_UI.Models.Dtos.UyelikPaketleri;
using YksProject.Web_UI.Models.ViewModel;

namespace YksProject.Web_UI.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ChatController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region ApiModel
        [HttpGet]
        [Route("/Chat/GetUsersAsync")]
        public async Task<IActionResult> GetUsersAsync([FromQuery] RequestDto model)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:56459/api/Message/GetUsers";

            // BolumAddViewModel nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

            // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // HTTP POST isteği yapın ve HttpContent'i kullanın
            var response = await client.PostAsync(apiURL, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var kisichatdtos = JsonConvert.DeserializeObject<IEnumerable<KisiChatDto>>(content);
                return Ok(kisichatdtos);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("/Chat/GetMessageAsync")]
        public async Task<IActionResult> GetMessageAsync(int MesajGondericiID, int MesajAliciID)
        {
            var model = new GetMessageDto();
            model.MesajAliciID=MesajAliciID;
            model.MesajGondericiID=MesajGondericiID;
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:56459/api/Message/GetChats";

            // BolumAddViewModel nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

            // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // HTTP POST isteği yapın ve HttpContent'i kullanın
            var response = await client.PostAsync(apiURL, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var kisichatdtos = JsonConvert.DeserializeObject<IEnumerable<MessageDto>>(content);
                return Ok(kisichatdtos);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpPost]
        [Route("/Chat/PostMessageAsync")]
        public async Task<IActionResult> PostMessageAsync([FromBody]MessageDto model)
        {
            model.OlusturulmaTarihi= DateTime.Now;
            model.OlusturanKisiID = model.MesajGondericiID;
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:56459/api/Message/SendMessage";

            // BolumAddViewModel nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

            // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // HTTP POST isteği yapın ve HttpContent'i kullanın
            var response = await client.PostAsync(apiURL, httpContent);
            if (response.IsSuccessStatusCode)
            {
                    var content = await response.Content.ReadAsStringAsync();
                    var kisichatdto = JsonConvert.DeserializeObject<MessageDto>(content);
                    return Ok(kisichatdto);

            }
            else
            {
                return BadRequest(response);
            }
        }
        #endregion
    }
}
