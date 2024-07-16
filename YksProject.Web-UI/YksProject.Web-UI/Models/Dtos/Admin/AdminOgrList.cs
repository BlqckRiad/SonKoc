using System;

namespace YksProject.Web_UI.Models.Dtos.Admin
{
    public class AdminOgrList
    {
        public int TabloID { get; set; }
        public string KisiAdi { get; set; }
        public string KisiSoyAdi { get; set; }
        public string KisiKullaniciAdi { get; set; }
        public string KisiEmail { get; set; }
        public string KisiTelNo { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
