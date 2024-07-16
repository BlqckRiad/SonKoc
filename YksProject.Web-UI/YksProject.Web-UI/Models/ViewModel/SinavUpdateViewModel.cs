using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class SinavUpdateViewModel
    {
        public int TabloID { get; set; }
        public string? SinavAdi { get; set; }
        public string? SinavKodu { get; set; }
        public int SinavSüresi { get; set; }
        public int SinavTipiID { get; set; }
        public bool SinaviKurumMuEkledi { get; set; } = false;
        public int SinaviEkleyenKurumID { get; set; }


        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    }
}
