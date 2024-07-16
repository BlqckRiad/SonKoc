using System;

namespace YksProject.Web_UI.Models.Dtos.Konular
{
    public class KonularUpdateDto
    {
        public int TabloID { get; set; }
        public string KonuAdi { get; set; }
        public int KonuDersID { get; set; }
        public int Konu1SeneSoruSayisi { get; set; }
        public int Konu2SeneSoruSayisi { get; set; }
        public int Konu3SeneSoruSayisi { get; set; }
        public string KonuAciklamasi { get; set; }
        public string KonuAciklamasiYapanKisi { get; set; }
        public string KonuAciklamasiYapanKisiRolu { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    }
}
