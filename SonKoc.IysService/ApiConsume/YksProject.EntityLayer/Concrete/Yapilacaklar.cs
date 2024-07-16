using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class Yapilacaklar
    {
        [Key]
        public int TabloID { get; set; }
        public string YapilacakGorevAdi { get; set; }
        public string YapilacakGorevAciklamasi { get; set; }
        public string YapilacakGorevIkon { get; set; }
        public string YapilacakGorevGun { get; set; }
        public string YapilacakGorevGunNo { get; set; }
        public int YapildiMi { get; set; }
        
        public DateTime GorevYapilmaTarihi { get; set; }

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
