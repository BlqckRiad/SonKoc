using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.Dtos
{
    public class KisiAytSayDogruYanlisDto
    {
       
        public int TabloID { get; set; }
    
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
   

        public int AytMatDogruSayisi { get; set; }
        public int AytMatYanlisSayisi { get; set; }
        public double AytMatNetSayisi { get; set; }
        public int AytFizikDogruSayisi { get; set; }
        public int AytFizikYanlisSayisi { get; set; }
        public double AytFizikNetSayisi { get; set; }
        public int AytKimyaDogruSayisi { get; set; }
        public int AytKimyaYanlisSayisi { get; set; }
        public double AytKimyaNetSayisi { get; set; }
        public int AytBiyolojiDogruSayisi { get; set; }
        public int AytBiyolojiYanlisSayisi { get; set; }
        public double AytBiyolojiNetSayisi { get; set; }

    }
}
