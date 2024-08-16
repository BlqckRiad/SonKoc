using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.DtosForUI
{
    public class KisiGirilenSon4DenemeDto
    {
        public int DenemeTabloID { get; set; }
        public int DenemeTipiID { get; set; }
        public string DenemeAdi { get; set; }
        public int DenemeDogruSayisi {  get; set; }
        public int DenemeYanlisSayisi { get; set; }
        public int DenemeBosSayisi { get; set; }
        public int DenemeGirenKisiID { get; set; }
        public DateTime DenemeGirisTarihi { get; set; }
    }
}
