using System;
using System.ComponentModel.DataAnnotations;

namespace YksProject.Web_UI.Models.Dtos.Admin
{
    public class BildirimList
    {
        public string TabloID { get; set; }
        public int GonderenKisiID { get; set; }
        public int AliciKisiID { get; set; }
       
        public string BildirimBasligi { get; set; }
        public string BildirimAciklamasi { get; set; }
        public bool BildirimAliciOkuduMu { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int SilenKisiID { get; set; }
        public bool SilindiMi { get; set; } = false;
    }
}
