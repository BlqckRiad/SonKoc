using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class Konular
    {
        [Key]
        public int TabloID { get; set; }
        public string KonuAdi { get; set; }
        public int KonuDersID { get; set; }
        public int Konu1SeneSoruSayisi { get; set; }
        public int Konu2SeneSoruSayisi { get; set; }
        public int Konu3SeneSoruSayisi { get; set; }
        public string KonuAciklamasi { get; set; }
        public string KonuAciklamasiYapanKisi { get; set; }
        public string KonuAciklamasiYapanKisiRolu { get; set; }

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
