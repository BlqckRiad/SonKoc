using System.ComponentModel.DataAnnotations;
using System;

namespace YksProject.Web_UI.Models.Dtos.PromoKey
{
    public class PromoKeyAddDto
    {
      
        public string PromoKod { get; set; }
        public string PromoKodNeİcin { get; set; }
        public int PromoKeyLimit { get; set; }
        public int PromoKeyKullanimSayisi { get; set; }
        public int PromoKeyYuzdeKacIndirim { get; set; }
        /// <summary>
        /// BaseModel
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    
    }
}
