using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class Kurum
    {
        [Key]
        public int TabloID { get; set; }
        public string KurumAdi { get; set; }
        public int KurumTipi { get; set; }
        public int KurumSahibiID { get; set; }
        public string KurumAdresi { get; set; }
        public int KurumAbonelikTipi { get; set; }
        public string KurumImageUrl { get; set; }
        public int KurumImageID { get; set; }
        public DateTime KurumAbonelikBasTarihi { get; set; }
        public DateTime KurumAbonelikBitisTarihi { get; set; }
        public int KurumAbonelikOgrenciSayisi { get; set; }

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
