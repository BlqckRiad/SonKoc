using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class ReferanslarimizUpdateViewModel
    {
        public int TabloID { get; set; }
        public string? ReferansAdi { get; set; }
        public string? ReferansAciklamasi { get; set; }
        public string? ReferansRolu { get; set; }
        public string? ReferansImage { get; set; }
        public string? ReferansPuani { get; set; }

        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
 
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    
    }
}
