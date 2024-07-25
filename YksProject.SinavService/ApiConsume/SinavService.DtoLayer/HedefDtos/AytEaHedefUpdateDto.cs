using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.HedefDtos
{
    public class AytEaHedefUpdateDto
    {
      
        public int TabloID { get; set; }
        public int AytMatDogruHedefi { get; set; }
        public int AytMatYanlisHedefi { get; set; }
        public int AytEdebiyatDogruHedefi { get; set; }
        public int AytEdebiyatYanlisHedefi { get; set; }
        public int AytTarih1DogruHedefi { get; set; }
        public int AytTarih1YanlisHedefi { get; set; }
        public int AytCografya1DogruHedefi { get; set; }
        public int AytCografya1YanlisHedefi { get; set; }
        public double HedefToplamNet { get; set; }
        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
      
    }
}
