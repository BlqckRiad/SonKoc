using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.EntityLayer.Concrete
{
    public class AytSayHedef
    {
        [Key]
        public int TabloID { get; set; }
        public int AytMatDogruHedefi { get; set; }
        public int AytMatYanlisHedefi { get; set; }
        public int AytFizikDogruHedefi { get; set; }
        public int AytFizikYanlisHedefi { get; set; }
        public int AytKimyaDogruHedefi { get; set; }
        public int AytKimyaYanlisHedefi { get; set; }
        public int AytBiyolojiDogruHedefi { get; set; }
        public int AytBiyolojiYanlisHedefi { get; set; }
        public double HedefToplamNet { get; set; }
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
