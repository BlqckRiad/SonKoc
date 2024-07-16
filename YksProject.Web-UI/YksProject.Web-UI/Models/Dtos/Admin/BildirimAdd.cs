using System.ComponentModel.DataAnnotations;
using System;

namespace YksProject.Web_UI.Models.Dtos.Admin
{
    public class BildirimAdd
    {
       
        public int GonderenKisiID { get; set; }
        public int AliciKisiID { get; set; }
        public string BildirimBasligi { get; set; }
        public string BildirimAciklamasi { get; set; }
        public bool BildirimAliciOkuduMu { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    
    }
}
