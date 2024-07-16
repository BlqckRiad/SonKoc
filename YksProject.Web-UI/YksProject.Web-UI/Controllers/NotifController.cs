using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YksProject.Web_UI.Models.Dtos.Admin;
using YksProject.Web_UI.Models.Dtos.Message;

namespace YksProject.Web_UI.Controllers
{
    public class NotifController : Controller
    {
        /// <summary>
        /// Mesaj gönderildiğinde bildirim gönderen applicationdır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Notif/SendMessageNotif")]
        public object SendMessageNotif(MessageDto model)
        {
            var data = new BildirimList();
            data.AliciKisiID = model.MesajAliciID;
            data.BildirimAliciOkuduMu = false;
            data.BildirimBasligi = "Yeni Bir Mesajın Var !!";
            data.BildirimAciklamasi = model.MesajText;
            data.GonderenKisiID = 0;
            data.OlusturanKisiID = 0;
            data.OlusturulmaTarihi = DateTime.Now;
            data.SilindiMi = false;
            data.BildirimAliciOkuduMu = false;

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
                // Veriyi "doc/" yoluna ekle ve benzersiz anahtar oluştur
                response = client.Push("MessageNotif/", data);
            }

            return response;
        }
    }
}
