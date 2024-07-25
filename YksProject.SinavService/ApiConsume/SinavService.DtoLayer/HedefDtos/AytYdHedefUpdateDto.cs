using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.HedefDtos
{
    public class AytYdHedefUpdateDto
    {
        public int TabloID { get; set; }
        public int AytYdDogruHedefi { get; set; }
        public int AytYdYanlisHedefi { get; set; }
        public double HedefToplamNet { get; set; }
        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
      
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    
    }
}
