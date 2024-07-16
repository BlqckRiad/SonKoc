using System;

namespace YksProject.Web_UI.Models.Dtos.PaketUyeTipleri
{
    public class PaketUyeTipleriUpdate
    {
        public int TabloID { get; set; }
        public string UyeTipiAdi { get; set; }
        public string UyeTipiAciklamasi { get; set; }


        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }

    }
}
