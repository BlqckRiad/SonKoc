using System;

namespace YksProject.Web_UI.Models
{
    public class Yapilacaklar
    {
        public int TabloID { get; set; }

        public int KisiID { get; set; }

        public string YapilacakGorevAdi { get; set; }
        public string YapilacakGorevAciklamasi { get; set; }
        public string YapilacakGorevIkon { get; set; }
        public string YapilacakGorevGun { get; set; }
        public string YapilacakGorevGunNo { get; set; }
        public int YapildiMi { get; set; }
        public DateTime GorevEklenmeTarihi { get; set; }
        public DateTime GorevYapilmaTarihi { get; set; }
    }
}
