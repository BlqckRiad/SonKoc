using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DtoLayer.DtosForUI
{
    public class MainPageLastGoalDto
    {
        public int HaftaID { get; set; }
        public double ToplamNet {  get; set; }
        public double HedefNet { get; set; }
        public double YuzdeselIfade { get; set; }
        public string HedefAciklamaMesaji { get; set; }
    }
}
