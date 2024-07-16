using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SonKocApp.BusinessLayer.Abstract;
using SonKocApp.ChatApi.Hubs;
using SonKocApp.DtoLayer.Dtos.Message;
using SonKocApp.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SonKocApp.ChatApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IKisiService _kisiService;
        private readonly IHubContext<ChatHub> _chathub;
        public MessageController(IMessageService messageService,IHubContext<ChatHub> hubContext, IKisiService kisiService)
        {
            _messageService = messageService;
            _chathub = hubContext;
            _kisiService = kisiService;
        }
        [HttpPost]
        public IActionResult GetChats(GetMessageDto model)
        {
            int id = model.MesajGondericiID;
            int toUserId = model.MesajAliciID;
            List<Message> chats = _messageService.TGetList()
              .Where(P => (P.MesajGondericiID == id && P.MesajAliciID == toUserId) ||
                          (P.MesajGondericiID == toUserId && P.MesajAliciID == id)).OrderBy(p=> p.OlusturulmaTarihi).ToList();
              

            return Ok(chats);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message model)
        {
            _messageService.TAdd(model);

            // Kullanıcıyı bulmaya çalış
            var user = ChatHub.Users.FirstOrDefault(p => p.Value == model.MesajAliciID);

            if (user.Key != null)
            {
                string connectionId = user.Key;

                // Kullanıcı çevrimiçi ise mesajı gönder
                await _chathub.Clients.Client(connectionId).SendAsync("Messages", model);
            }





            return Ok(model);
        }

        [HttpPost]
        public IActionResult GetUsers([FromBody]RequestDto model)
        {
            // Adım 1: Kullanıcının mesajlarını filtreleyip, OlusturulmaTarihi'ne göre sıralayın
            var messages = _messageService.TGetList()
                                 .Where(m => m.MesajGondericiID == model.Id || m.MesajAliciID == model.Id)
                                 .OrderByDescending(m => m.OlusturulmaTarihi)
                                 .ToList();

            // Adım 2: Kullanıcının mesajlaştığı kişilerin ID'lerini alın
            var userIds = messages.Select(m => m.MesajGondericiID == model.Id ? m.MesajAliciID : m.MesajGondericiID)
                                  .Distinct()
                                  .ToList();

            // Adım 3: Kullanıcı ID'lerine göre kullanıcı verilerini alın ve en son mesajlaşma tarihine göre sıralayın
            var users = userIds.Select(id => _kisiService.TGetByid(id))
                               .Where(user => user != null)
                               .OrderByDescending(user => messages.First(m => m.MesajGondericiID == user.TabloID || m.MesajAliciID == user.TabloID).OlusturulmaTarihi)
                               .ToList();

            var userDtos = users.Select(user => new KisiChatDto
            {
                TabloID = user.TabloID,
                KisiKullaniciAdi = user.KisiKullaniciAdi,
                KisiImageUrl = user.KisiImageUrl,
                UserOnlineMi = user.UserOnlineMi
            }).ToList();

            // Kullanıcı verilerini döndürüyoruz
            return Ok(userDtos);
        }

        [HttpPost]
        public IActionResult TestSendMessage(Message model)
        {
            _messageService.TAdd(model);
            return Ok();
        }

        [HttpGet]
        public IActionResult Deneme()
        {
            var x = ChatHub.Users;
            return Ok(x);
        }

    }
}
