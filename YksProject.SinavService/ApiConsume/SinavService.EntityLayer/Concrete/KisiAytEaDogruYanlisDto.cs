using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.EntityLayer.Concrete
{
    public class KisiAytEaDogruYanlisDto
    {

        [Key]
        public int TabloID { get; set; }
        public string SinavAdi { get; set; }
        public int GirilenSinavID { get; set; }
        public int GirenKisiID { get; set; }


        public int AytMatDogruSayisi { get; set; }
        public int AytMatYanlisSayisi { get; set; }
        public double AytMatNetSayisi { get; set; }
        public int AytEdebiyatDogruSayisi { get; set; }
        public int AytEdebiyatYanlisSayisi { get; set; }
        public double AytEdebiyatNetSayisi { get; set; }
        public int AytTarih1DogruSayisi { get; set; }
        public int AytTarih1YanlisSayisi { get; set; }
        public double AytTarih1NetSayisi { get; set; }

        public int AytCografya1DogruSayisi { get; set; }
        public int AytCografya1YanlisSayisi { get; set; }
        public double AytCografya1NetSayisi { get; set; }


        public DateTime BitisTarihi { get; set; }
    }
}
