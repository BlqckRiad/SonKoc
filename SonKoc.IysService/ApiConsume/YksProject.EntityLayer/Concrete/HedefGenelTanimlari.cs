using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class HedefGenelTanimlari
    {
        [Key]
        public int TabloID { get; set; }
        public int HedefYapanKisiID { get; set; }
        public int HedefYapanKisiBolumID { get; set; }
        public int HedefTytID { get; set; }
        public int HedefAytID { get; set; }
        public double HedefPuani {  get; set; }
        public int HedefSiralama {  get; set; }
        
        public string HedefNotu {  get; set; }
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
