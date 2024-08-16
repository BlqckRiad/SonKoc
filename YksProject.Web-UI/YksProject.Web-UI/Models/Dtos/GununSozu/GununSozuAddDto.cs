using System;

namespace YksProject.Web_UI.Models.Dtos.GununSozu
{
    public class GununSozuAddDto
    {

        public string Soz { get; set; }
        /// <summary>
        /// BaseModel
        /// </summary>
        public DateTime OlusturulmaTarihi { get; set; }
        public int OlusturanKisiID { get; set; }

    }
}
