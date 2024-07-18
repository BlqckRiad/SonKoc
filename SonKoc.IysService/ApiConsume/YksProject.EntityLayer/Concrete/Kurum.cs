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
        public string KurumSahibiAdi { get; set; }
        public string KurumAdresi { get; set; }
        public string KurumImageUrl { get; set; }
        public int KurumImageID { get; set; }
        public int KurumOgrenciSayisi { get; set; }
        public int KurumMaxOgrenciLimiti { get; set; }
        public int KurumTelNo {  get; set; }
        public int KurumSahibiTelNo {  get; set; }
        public string KurumSahibiEmail {  get; set; }
        public string KurumWebSiteUrl {  get; set; }
        public string KurumInstaKullaniciAdi {  get; set; }
        public int KurumTipiID { get; set; } // 1 ise : Dershane , 2 ise koç-öğretmen
        //Giriş Yaparken Kullanılacak !!
        public string KurumEmail { get; set; }
        public string KurumPassword { get; set; }

        public bool KurumOnlineMi { get; set; }
        public DateTime KurumSonGirisTarihi { get; set; }
        public DateTime KurumSonCikisTarihi { get; set; }

        public int KurumToplamGiris { get; set; }
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
