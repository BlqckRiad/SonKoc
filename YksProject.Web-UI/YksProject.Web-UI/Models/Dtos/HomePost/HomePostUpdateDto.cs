using System.ComponentModel.DataAnnotations;
using System;

namespace YksProject.Web_UI.Models.Dtos.HomePost
{
    public class HomePostUpdateDto
    {
        
        public int TabloID { get; set; }
        
        public string PostAdi { get; set; }
        
        public string PostAciklamasi { get; set; }
        public string PostMedyaUrl { get; set; }
        public int PostMedyaID { get; set; }
        public bool PostYayindaMi { get; set; }

        public string PostSahibi { get; set; }
        public int PostGorulmeSayisi { get; set; }
        public int PostTiklanmaSayisi { get; set; }


        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
     
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
       
    }
}
