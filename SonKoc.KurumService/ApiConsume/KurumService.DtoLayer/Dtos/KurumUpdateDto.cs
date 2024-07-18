using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumService.DtoLayer.Dtos
{
    public class KurumUpdateDto
    {
        public int TabloID { get; set; }
        public string KurumAdi { get; set; }
        public string KurumSahibiAdi { get; set; }
        public string KurumAdresi { get; set; }
        public string KurumImageUrl { get; set; }
        public int KurumImageID { get; set; }
        public int KurumOgrenciSayisi { get; set; }
        public int KurumMaxOgrenciLimiti { get; set; }
        public int KurumTelNo { get; set; }
        public int KurumSahibiTelNo { get; set; }
        public string KurumSahibiEmail { get; set; }
        public string KurumWebSiteUrl { get; set; }
        public string KurumInstaKullaniciAdi { get; set; }
        public int KurumTipiID { get; set; } // 1 ise : Dershane , 2 ise koç-öğretmen



        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>

        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        
       
    }
}
