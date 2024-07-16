using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class ReferanslarimizAddViewModel
    {

        public string? ReferansAdi { get; set; }
        public string? ReferansAciklamasi { get; set; }
        public string? ReferansImage { get; set; }
        public string? ReferansRolu { get; set; }
        public string? ReferansPuani { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    }
}
