using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.EntityLayer.Concrete
{
    public class AytSozelGirisTablosu
    {
        [Key]
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }


        public int AytEdebiyatDogruSayisi { get; set; }
        public int AytEdebiyatYanlisSayisi { get; set; }
        public double AytEdebiyatNetSayisi { get; set; }
        public int AytTarih1DogruSayisi { get; set; }
        public int AytTarih1YanlisSayisi { get; set; }
        public double AytTarih1NetSayisi { get; set; }

        public int AytCografya1DogruSayisi { get; set; }
        public int AytCografya1YanlisSayisi { get; set; }
        public double AytCografya1NetSayisi { get; set; }

        public int AytTarih2DogruSayisi { get; set; }
        public int AytTarih2YanlisSayisi { get; set; }
        public double AytTarih2NetSayisi { get; set; }

        public int AytCografya2DogruSayisi { get; set; }
        public int AytCografya2YanlisSayisi { get; set; }
        public double AytCografya2NetSayisi { get; set; }


        public int AytFelsefeDogruSayisi { get; set; }
        public int AytFelsefeYanlisSayisi { get; set; }
        public double AytFelsefeNetSayisi { get; set; }

        public int AytDinDogruSayisi { get; set; }
        public int AytDinYanlisSayisi { get; set; }
        public double AytDinNetSayisi { get; set; }


        public int AytEdebiyatToplamDakika { get; set; }
        public int AytTarih1ToplamDakika { get; set; }
        public int AytCografya1ToplamDakika { get; set; }
        public int AytTarih2ToplamDakika { get; set; }
        public int AytCografya2ToplamDakika { get; set; }

        public int AytFelsefeToplamDakika { get; set; }
        public int AytDinToplamDakika { get; set; }

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
