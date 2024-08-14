using System.ComponentModel.DataAnnotations;
using System;

namespace YksProject.Web_UI.Models.Dtos.PromoKey
{
    public class PromoKeyListDto
    {
        
        public int TabloID { get; set; }
        public string PromoKod { get; set; }
        public string PromoKodNeİcin { get; set; }
        public int PromoKeyLimit { get; set; }
        public int PromoKeyKullanimSayisi { get; set; }
        public int PromoKeyYuzdeKacIndirim { get; set; }
       
        public DateTime PromoKeySonKullanimTarihi { get; set; }
    }
}
