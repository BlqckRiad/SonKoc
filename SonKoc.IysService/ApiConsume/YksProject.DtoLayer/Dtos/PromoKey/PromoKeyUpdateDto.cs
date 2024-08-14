using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.DtoLayer.Dtos.PromoKey
{
    public class PromoKeyUpdateDto
    {

        public int TabloID { get; set; }
        public string PromoKod { get; set; }
        public string PromoKodNeİcin { get; set; }
        public int PromoKeyLimit { get; set; }
        public int PromoKeyKullanimSayisi { get; set; }
        public int PromoKeyYuzdeKacIndirim { get; set; }

        public DateTime PromoKeySonKullanimTarihi { get; set; }
        /// <summary>
        /// BaseModel
        /// </summary>

        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    }
}
