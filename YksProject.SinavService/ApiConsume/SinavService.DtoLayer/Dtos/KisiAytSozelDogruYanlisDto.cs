using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.Dtos
{
    public class KisiAytSozelDogruYanlisDto
    {
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }
        public DateTime BaslangicZamani { get; set; }


        public int AytEdebiyatDogruSayisi { get; set; }
        public int AytEdebiyatYanlisSayisi { get; set; }
        public double AytEdebiyatNetSayisi { get; set; }
        public int AytTarih1DogruSayisi { get; set; }
        public int AytTarih1YanlisSayisi { get; set; }
        public double AytTarih1NetSayisi { get; set; }

        public int AytCografya1DogruSayisi { get; set; }
        public int AytCografya1YanlisSayisi { get; set; }
        public double AytCografya1NetSayisi { get; set; }

        public int AytTarih2DogruSayisi { get; set; }
        public int AytTarih2YanlisSayisi { get; set; }
        public double AytTarih2NetSayisi { get; set; }

        public int AytCografya2DogruSayisi { get; set; }
        public int AytCografya2YanlisSayisi { get; set; }
        public double AytCografya2NetSayisi { get; set; }


        public int AytFelsefeDogruSayisi { get; set; }
        public int AytFelsefeYanlisSayisi { get; set; }
        public double AytFelsefeNetSayisi { get; set; }

        public int AytDinDogruSayisi { get; set; }
        public int AytDinYanlisSayisi { get; set; }
        public double AytDinNetSayisi { get; set; }
    }
}
