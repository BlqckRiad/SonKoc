using System;

namespace YksProject.Web_UI.Models.Dtos.GununSozu
{
    public class GununSozuUpdateDto
    {
        public int TabloID { get; set; }
        public string Soz { get; set; }
        /// <summary>
        /// BaseModel
        /// </summary>
     
        public DateTime GuncellenmeTarihi { get; set; }
        public int GuncelleyenKisiID { get; set; }
  
    }
}
