using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.EntityLayer.Concrete
{
    public class Sinav
    {
        [Key]
        public int TabloID { get; set; }
        public string? SinavAdi { get; set; }
        public string? SinavKodu { get; set; }
        public int SinavSüresi { get; set; }
        public int SinavTipiID { get; set; }
        public bool SinaviKurumMuEkledi { get; set; } = false;
        public int SinaviEkleyenKurumID { get; set; }


        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int SilenKisiID { get; set; }
        public bool SilindiMi { get; set; } = false;
    }
}
