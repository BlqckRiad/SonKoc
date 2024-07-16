using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.DtoLayer.Dtos.Message
{
    public class KisiChatDto
    {
        public int TabloID { get; set; }
        public string? KisiKullaniciAdi { get; set; }
        public string? KisiImageUrl { get; set; }

        public bool UserOnlineMi { get; set; }
    }
}
