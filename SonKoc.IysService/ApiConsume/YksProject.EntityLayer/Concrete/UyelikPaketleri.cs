using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class UyelikPaketleri
    {
        [Key]
        public int TabloID { get; set; }
        
        public string PaketAdi { get; set; }
        public string PaketAciklamasi { get; set; }
        public int PaketImageID { get; set; }
        public string PaketImageUrl { get; set; }
        public int PaketUcreti { get; set; }
        public int PaketIndirimOrani { get; set; }
        public int PaketUyeTipiID { get; set; } //PaketUyeTipleri Tablosundan Refere Edilmektedir.
        public int PaketUyeSayısı { get; set; }
        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int SilenKisiID { get; set; }
        public bool SilindiMi { get; set; } = false;
    }
}
