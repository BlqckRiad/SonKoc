using System;

namespace YksProject.Web_UI.Models.Dtos
{
    public class MedyaKutuphanesiAddDto
    {
      
        public string MedyaUrl { get; set; }
        public string MedyaAdi { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }
    }
}
