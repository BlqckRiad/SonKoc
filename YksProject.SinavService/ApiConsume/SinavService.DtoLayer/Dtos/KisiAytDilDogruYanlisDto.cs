using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.Dtos
{
    public class KisiAytDilDogruYanlisDto
    {
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }
        public int AytDilDogruSayisi { get; set; }
        public int AytDilYanlisSayisi { get; set; }
        public double AytDilNetSayisi { get; set; }
        public int AytDilToplamDakika { get; set; }


        public DateTime BitisTarihi { get; set; }
    }
}
