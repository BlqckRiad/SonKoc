using System;

namespace YksProject.Web_UI.Models.Dtos.UyelikPaketleri
{
    public class UyelikPaketiAddDto
    {
        public int TabloID { get; set; }

        public string PaketAdi { get; set; }
        public string PaketAciklamasi { get; set; }
        public int PaketImageID { get; set; }
        public string PaketImageUrl { get; set; }
        public int PaketUcreti { get; set; }
        public int PaketIndirimOrani { get; set; }
        public int PaketUyeTipiID { get; set; } //PaketUyeTipleri Tablosundan Refere Edilmektedir.
        public int PaketUyeSayısı { get; set; }
        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }


    }
}
