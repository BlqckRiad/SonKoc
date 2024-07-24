using System;

namespace YksProject.Web_UI.Models.Dtos.Kurum
{
    public class KurumGetOgrenci
    {
        public int TabloID { get; set; }
        public string? KisiAdi { get; set; }
        public string? KisiSoyAdi { get; set; }
        public string? KisiKullaniciAdi { get; set; }
        public string? KisiEmail { get; set; }
        public string? KisiTelNo { get; set; }
        public DateTime KisiDogumTarihi { get; set; }
        public int KisiYasi { get; set; }
        public int KisiObpDegeri { get; set; }
        public string? KisiImageUrl { get; set; }
        public int UserToplamGirisSayisi { get; set; }
    }
}
