using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class TytSinavGirisTablosu
    {
        [Key]
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }
        public int TytTurkceDogruSayisi { get; set; }
        public int TytTurkceYanlisSayisi { get; set; }
        public double TytTurkceNetSayisi { get; set; }
        public int TytMatematikDogruSayisi { get; set; }
        public int TytMatematikYanlisSayisi { get; set; }
        public double TytMatematikNetSayisi { get; set; }
        public int TytFenDogruSayisi { get; set; }
        public int TytFenYanlisSayisi { get; set; }
        public double TytFenNetSayisi { get; set; }
        public int TytSosyalDogruSayisi { get; set; }
        public int TytSosyalYanlisSayisi { get; set; }
        public double TytSosyalNetSayisi { get; set; }

        public int TytTurkceToplamDakika { get; set; }
        public int TytFenToplamDakika { get; set; }
        public int TytMatematikToplamDakika { get; set; }
        public int TytSosyalToplamDakika { get; set; }
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
