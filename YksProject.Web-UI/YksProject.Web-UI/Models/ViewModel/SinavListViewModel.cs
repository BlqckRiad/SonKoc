using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class SinavListViewModel
    {
        public int TabloID { get; set; }
        public string? SinavAdi { get; set; }
        public string? SinavKodu { get; set; }
        public int SinavSüresi { get; set; }
        public int SinavTipiID { get; set; }
        public bool SinaviKurumMuEkledi { get; set; }
        public int SinaviEkleyenKurumID { get; set; }
    }
}
