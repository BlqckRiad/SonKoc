using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YksProject.EntityLayer.Concrete
{
    public class TamamlanmisKonular
    {
        [Key]
        public int TabloID { get; set; }
        public int KonuID { get; set; }
        public int TamamlayanKisiID { get; set; }
        public DateTime TamamlanmaTarihi { get; set; }
    }
}
