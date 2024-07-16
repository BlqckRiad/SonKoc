using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class BolumAddViewModel
    {
        public string BolumAdi { get; set; }
        public string BolumAdKodu { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int SilenKisiID { get; set; }
        public bool SilindiMi { get; set; } = false;
    }
}
