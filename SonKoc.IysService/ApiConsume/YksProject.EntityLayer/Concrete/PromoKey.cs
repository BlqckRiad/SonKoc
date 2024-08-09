using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class PromoKey
    {
        [Key]
        public  int TabloID { get; set; }
        public string  PromoKod { get; set; }
        public string PromoKodNeİcin { get; set;}
        public int PromoKeyLimit { get; set; }
        public int PromoKeyKullanimSayisi { get; set; }
        public int PromoKeyYuzdeKacIndirim { get; set; }
        /// <summary>
        /// BaseModel
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
