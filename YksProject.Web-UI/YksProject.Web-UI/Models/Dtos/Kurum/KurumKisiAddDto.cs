using System;

namespace YksProject.Web_UI.Models.Dtos.Kurum
{
    public class KurumKisiAddDto
    {
        public string? KisiAdi { get; set; }
        public string? KisiSoyAdi { get; set; }
        public string? KisiKullaniciAdi { get; set; }
        public string? KisiEmail { get; set; }
        public string? KisiPassword { get; set; }
        public DateTime KisiDogumTarihi { get; set; }

        public bool KisiKurumSahibiMi { get; set; } = false;

        public int KisiIlgiliKurumID { get; set; }
        public int KisiCinsiyetID { get; set; }
    }
}
