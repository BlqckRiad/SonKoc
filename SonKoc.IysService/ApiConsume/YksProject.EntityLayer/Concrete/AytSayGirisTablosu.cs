using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class AytSayGirisTablosu
    {
        [Key]
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }

        public int AytMatDogruSayisi { get; set; }
        public int AytMatYanlisSayisi { get; set; }
        public double AytMatNetSayisi { get; set; }
        public int AytFizikDogruSayisi { get; set; }
        public int AytFizikYanlisSayisi { get; set; }
        public double AytFizikNetSayisi { get; set; }
        public int AytKimyaDogruSayisi { get; set; }
        public int AytKimyaYanlisSayisi { get; set; }
        public double AytKimyaNetSayisi { get; set; }
        public int AytBiyolojiDogruSayisi { get; set; }
        public int AytBiyolojiYanlisSayisi { get; set; }
        public double AytBiyolojiNetSayisi { get; set; }


        public int AytMatToplamDakika { get; set; }
        public int AytFizikToplamDakika { get; set; }
        public int AytKimyaToplamDakika { get; set; }
        public int AytBiyolojiToplamDakika { get; set; }

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
