using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class AytYDGirisTablosu
    {
        [Key]
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }
        public int AytDilDogruSayisi { get; set; }
        public int AytDilYanlisSayisi { get; set; }
        public double AytDilNetSayisi { get; set; }
        public int AytDilToplamDakika { get; set; }
     

        public DateTime BitisTarihi { get; set; }

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
