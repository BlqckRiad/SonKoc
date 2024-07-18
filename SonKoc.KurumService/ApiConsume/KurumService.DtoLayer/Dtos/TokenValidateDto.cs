using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumService.DtoLayer.Dtos
{
    public class TokenValidateDto
    {
        public int TabloID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string KisiImageUrl { get; set; }
    }
}
