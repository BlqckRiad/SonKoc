using System.ComponentModel.DataAnnotations;
using System;

namespace YksProject.Web_UI.Models.Dtos.Message
{
    public class MessageDto
    {
        
        public int MesajGondericiID { get; set; }
        public int MesajAliciID { get; set; }
        public bool MesajAliciOkuduMu { get; set; }
      
        public string MesajGonderenKisiImageUrl { get; set; } = string.Empty;
        public string MesajText { get; set; } = string.Empty;


        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }

    }
}
