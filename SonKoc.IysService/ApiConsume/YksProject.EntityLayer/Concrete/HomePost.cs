using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class HomePost
    {
        [Key]
        public int TabloID {  get; set; }
        [Required]
        public string PostAdi {  get; set; }
        [Required]
        public string PostAciklamasi {  get; set; }
        public string PostMedyaUrl {  get; set; }
        public int PostMedyaID {  get; set; }
        public bool PostYayindaMi {  get; set; }

        public string PostSahibi {  get; set; }
        public int PostGorulmeSayisi { get; set; }
        public int PostTiklanmaSayisi { get; set; }


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
