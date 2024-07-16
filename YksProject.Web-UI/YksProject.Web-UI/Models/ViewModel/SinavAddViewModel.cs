using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class SinavAddViewModel
    {
        public string? SinavAdi { get; set; }
        public string? SinavKodu { get; set; }
        public int SinavSüresi { get; set; }
        public int SinavTipiID { get; set; }
        public bool SinaviKurumMuEkledi { get; set; } = false;
        public int SinaviEkleyenKurumID { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public int OlusturanKisiID { get; set; }
    }
}
