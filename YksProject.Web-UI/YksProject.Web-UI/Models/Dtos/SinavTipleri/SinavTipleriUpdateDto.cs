using System;

namespace YksProject.Web_UI.Models.Dtos.SinavTipleri
{
    public class SinavTipleriUpdateDto
    {
        public int TabloID { get; set; }
        public string SinavTipiAdi { get; set; }

        /// <summary>
        /// BaseModel Her Tabloda Olması Gereken İfadeler
        /// </summary>
        public int GuncelleyenKisiID { get; set; }
    }
}
