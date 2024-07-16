using System;

namespace YksProject.Web_UI.Models.Dtos.PaketUyeTipleri
{
    public class PaketUyeTipleriAdd
    {
        public string UyeTipiAdi { get; set; }
        public string UyeTipiAciklamasi { get; set; }


        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }

    }
}
