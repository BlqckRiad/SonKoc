using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.DtoLayer.Dtos.PromoKey
{
    public class PromoKeyAddDto
    {
        public string PromoKod { get; set; }
        public string PromoKodNeİcin { get; set; }
        public int PromoKeyLimit { get; set; }

        public DateTime PromoKeySonKullanimTarihi { get; set; }
  
        public int PromoKeyYuzdeKacIndirim { get; set; }
        /// <summary>
        /// BaseModel
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    }
}
