using System;

namespace YksProject.Web_UI.Models.ViewModel
{
    public class DerslerAddViewModel
    {
        public string? DersAdi { get; set; }
        public int DersBolumID { get; set; }
    

        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    }
}
