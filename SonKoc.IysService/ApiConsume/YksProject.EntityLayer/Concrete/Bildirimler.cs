using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class Bildirimler
    {
        [Key]
        public int TabloID { get; set; }
        public int GonderenKisiID { get; set; }
        public int AliciKisiID { get; set; }
        [MaxLength(50)]
        public string BildirimBasligi { get; set; }
        public string BildirimAciklamasi { get; set; }
        public  bool BildirimAliciOkuduMu { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int SilenKisiID { get; set; }
        public bool SilindiMi { get; set; } = false;
    }
}
