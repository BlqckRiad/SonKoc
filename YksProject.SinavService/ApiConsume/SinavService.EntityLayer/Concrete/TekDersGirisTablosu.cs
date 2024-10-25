using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.EntityLayer.Concrete
{
    public class TekDersGirisTablosu
    {
        [Key]
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirilenTekDersTipiID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }
        public int TekDersDogruSayisi { get; set; }
        public int TekDersYanlisSayisi { get; set; }
        public double TekDersNetSayisi { get; set; }
        public int TekDersToplamDakika { get; set; }


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
