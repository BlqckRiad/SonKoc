using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.EntityLayer.Concrete
{
    public class Kisi
    {
        [Key]
        public int TabloID { get; set; }
        public string? KisiAdi { get; set; }
        public string? KisiSoyAdi { get; set; }
        public string? KisiKullaniciAdi { get; set; }
        public string? KisiEmail { get; set; }
        public string? KisiPassword { get; set; }
        public string? KisiTelNo { get; set; }
        public bool KisiEmailChecked { get; set; } = false;
        public bool KisiTelNoChecked { get; set; } = false;
        public DateTime KisiDogumTarihi { get; set; }
        public int KisiYasi { get; set; }
        public int KisiObpDegeri { get; set; }
        public string? KisiImageID { get; set; }
        public string? KisiImageUrl { get; set; }

        public bool UserOnlineMi { get; set; }
        public bool KisiKurumSahibiMi { get; set; } = false;

        public int KisiIlgiliKurumID { get; set; }
        public int KisiCinsiyetID { get; set; }

        public int KisiBolumID { get; set; }
        public bool KisiMezunOgrencisiMi { get; set; }

        public int RolID { get; set; }

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
