using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.Dtos
{
    public class SinavUpdateDto
    {
      
        public int TabloID { get; set; }
        public string? SinavAdi { get; set; }
        public string? SinavKodu { get; set; }
        public int SinavSüresi { get; set; }
        public int SinavTipiID { get; set; }
        public bool SinaviKurumMuEkledi { get; set; } = false;
        public int SinaviEkleyenKurumID { get; set; }
        public DateTime SinavBaslangicTarihi { get; set; }
        public DateTime SinavBitisTarihi { get; set; }
        public bool SinavBittiMi { get; set; } = false;

        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
       
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
    
    }
}
