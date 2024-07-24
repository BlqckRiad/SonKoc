using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class TytHedef
    {
        [Key]
        public int TabloID { get; set; }
        public int TytMatDogruHedefi { get; set; }
        public int TytMatYanlisHedefi { get; set; }
        public int TytFenDogruHedefi { get; set; }
        public int TytFenYanlisHedefi { get; set; }
        public int TytTurkceDogruHedefi { get; set; }
        public int TytTurkceYanlisHedefi { get; set; }
        public int TytSosyalDogruHedefi { get; set; }
        public int TytSosyalYanlisHedefi { get; set; }
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
