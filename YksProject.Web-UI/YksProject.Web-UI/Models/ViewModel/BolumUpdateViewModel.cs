using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class BolumUpdateViewModel
    {
        public int TabloID { get; set; }
        public string BolumAdi { get; set; }
        public string BolumAdKodu { get; set; }

        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    }
}
