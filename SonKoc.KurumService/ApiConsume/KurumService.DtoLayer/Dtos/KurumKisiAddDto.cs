using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumService.DtoLayer.Dtos
{
    public class KurumKisiAddDto
    {
        public string? KisiAdi { get; set; }
        public string? KisiSoyAdi { get; set; }
        public string? KisiKullaniciAdi { get; set; }
        public string? KisiEmail { get; set; }
        public string? KisiPassword { get; set; }
        public DateTime KisiDogumTarihi { get; set; }

        public bool KisiKurumSahibiMi { get; set; } = false;

        public int KisiIlgiliKurumID { get; set; }
        public int KisiCinsiyetID { get; set; }
    }
}
