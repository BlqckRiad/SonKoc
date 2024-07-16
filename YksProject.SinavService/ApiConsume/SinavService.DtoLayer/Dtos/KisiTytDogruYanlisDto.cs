using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.Dtos
{
    public class KisiTytDogruYanlisDto
    {
        public int TabloID { get; set; }
        public int GirenKisiID { get; set; }
        public int TytTurkceDogruSayisi { get; set; }
        public int TytTurkceYanlisSayisi { get; set; }
        public double TytTurkceNetSayisi { get; set; }
        public int TytMatematikDogruSayisi { get; set; }
        public int TytMatematikYanlisSayisi { get; set; }
        public double TytMatematikNetSayisi { get; set; }
        public int TytFenDogruSayisi { get; set; }
        public int TytFenYanlisSayisi { get; set; }
        public double TytFenNetSayisi { get; set; }
        public int TytSosyalDogruSayisi { get; set; }
        public int TytSosyalYanlisSayisi { get; set; }
        public double TytSosyalNetSayisi { get; set; }

    }
}
