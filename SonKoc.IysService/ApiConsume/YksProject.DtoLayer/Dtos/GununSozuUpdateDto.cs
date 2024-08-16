using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.DtoLayer.Dtos
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
