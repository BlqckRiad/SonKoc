using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.DtoLayer.Dtos.Message
{
    public class SendMessageDto
    {
        public int MesajGondericiID { get; set; }
        public int MesajAliciID { get; set; }
        public bool MesajAliciOkuduMu { get; set; }
        [MaxLength(80)]
        public string MesajGonderenKisiImageUrl { get; set; } = string.Empty;
        public string MesajText { get; set; } = string.Empty;
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    }
}
