using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class GirilenSinav 
    {
        [Key]
        public int TabloID { get; set; }
        public int GirilenSinavID { get; set; }
        public string GirilenSinavAdi { get; set; }
        public int GirilenSinavinTipi { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime SinavGirisTarihi { get; set; }
        public DateTime SinavBitisTarihi { get; set; }
        public int SinavSonucu { get; set; }

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
