using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.DtoLayer.Dtos.Message
{
    public class GetMessageDto
    {
        public int MesajGondericiID { get; set; }
        public int MesajAliciID { get; set; }
    }
}
