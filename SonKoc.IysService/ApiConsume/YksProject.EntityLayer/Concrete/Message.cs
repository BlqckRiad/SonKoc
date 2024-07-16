using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class Message {
        [Key] 
        public int TabloID { get; set; }
        public int MesajGondericiID { get; set; }
        public int MesajAliciID { get; set; }
        public bool MesajAliciOkuduMu { get; set; }
        [MaxLength(80)]
        public string MesajGonderenKisiImageUrl { get; set; }
        public string MesajText { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int SilenKisiID { get; set; }
        public bool SilindiMi { get; set; } = false;
    }
}
