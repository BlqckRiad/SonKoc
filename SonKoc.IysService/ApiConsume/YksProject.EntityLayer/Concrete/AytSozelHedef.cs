using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class AytSozelHedef
    {
        [Key]
        public int TabloID { get; set; }
        public int AytMatDogruHedefi { get; set; }
        public int AytMatYanlisHedefi { get; set; }
        public int AytEdebiyatDogruHedefi { get; set; }
        public int AytEdebiyatYanlisHedefi { get; set; }
        public int AytTarih1DogruHedefi { get; set; }
        public int AytTarih1YanlisHedefi { get; set; }
        public int AytCografya1DogruHedefi { get; set; }
        public int AytCografya1YanlisHedefi { get; set; }
        public int AytTarih2DogruHedefi { get; set; }
        public int AytTarih2YanlisHedefi { get; set; }
        public int AytCografya2DogruHedefi { get; set; }
        public int AytCografya2YanlisHedefi { get; set; }
        public int AytDinDogruHedefi { get; set; }
        public int AytDinYanlisHedefi { get; set; }
        public int AytFelsefeDogruHedefi { get; set; }
        public int AytFelsefeYanlisHedefi { get; set; }
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
