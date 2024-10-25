using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
using SinavService.DtoLayer.DtosForUI;
using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinavController : ControllerBase
    {
        private readonly ISinavService _sinavservice;
        private readonly IKisiService _kisiservice;
        private readonly ITytSinavGirisTablosuService _tytSinavGirisTablosuService;
        private readonly IAytSayService _aytsayService;
        private readonly IAytEaService _ayteaService;
        private readonly IAytSozelService _aytsozelService;
        private readonly IAytDilService _aytydService;
        public SinavController(ISinavService sinavService, IKisiService kisiService,
            ITytSinavGirisTablosuService tytSinavGirisTablosuService,
            IAytSayService k1,
            IAytEaService k2,
            IAytSozelService k3,
            IAytDilService k4
           )
        {
            _sinavservice = sinavService;
            _kisiservice = kisiService;
            _tytSinavGirisTablosuService = tytSinavGirisTablosuService;
            _aytsayService = k1;
            _ayteaService = k2;
            _aytsozelService = k3;
            _aytydService = k4;
        }
        [HttpGet]
        [Route("/Sinav/KisiGenelSinavlariGetir")]
        public IActionResult KisiGenelSinavlariGetir()
        {
            var result = _sinavservice.TGetList().Where(x => x.SilindiMi == false && x.SinaviKurumMuEkledi == false);
            return Ok(result);
        }
        [HttpGet]
        [Route("/Sinav/SinavGetWithid/{id}")]
        public IActionResult SinavGetWithid(int id)
        {
            var result = _sinavservice.TGetByid(id);
            if(result.SilindiMi==true)
            {
                return BadRequest("Veri Önceden Silinmiş");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("/Sinav/KisiKurumSinavlariGetir")]
        public IActionResult KisiKurumSinavlariGetir(KisiKurumSinavDto model)
        {
            var result = _sinavservice.TGetList().Where(x=> x.SilindiMi==false && x.SinaviEkleyenKurumID==model.KisiKurumID && x.SinaviKurumMuEkledi == true);
            return Ok(result);
        }
        [HttpPost]
        [Route("/Sinav/SinavEkle")]
        public IActionResult SinavEkle(Sinav model)
        {
            _sinavservice.TAdd(model);
            return Ok();
        }
        [HttpPost]
        [Route("/Sinav/SinavGuncelle")]
        public IActionResult SinavGuncelle(SinavUpdateDto model)
        {
            var result = _sinavservice.TGetByid(model.TabloID);
            result.SinavAdi = model.SinavAdi;
            result.SinavKodu = model.SinavKodu;
            result.SinavSüresi = model.SinavSüresi;
            result.SinavTipiID = model.SinavTipiID;
            result.SinavSüresi = model.SinavSüresi;
            result.SinaviKurumMuEkledi = model.SinaviKurumMuEkledi;
            result.SinaviEkleyenKurumID = model.SinaviEkleyenKurumID;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            result.GuncellenmeTarihi = DateTime.Now;
            _sinavservice.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        [Route("/Sinav/SinavSil")]
        public IActionResult SinavSil(DeleteDto model)
        {
            var result = _sinavservice.TGetByid(model.TabloID);
            if(result == null)
            {
                return BadRequest("Sınav Bulunamadı");
            }
            result.SilinmeTarihi = DateTime.Now;
            result.SilindiMi = true;
            result.SilenKisiID = model.SilenKisiID;
            _sinavservice.TUpdate(result);
            return Ok();
        }
        [HttpGet]
        [Route("/Sinav/KisiGirilenSinavSayisiGet")]
        public IActionResult KisiGirilenSinavSayisiGet(int id)
        {
            var kisibolum = _kisiservice.TGetByid(id);
            if(kisibolum == null)
            {
                return BadRequest("Kişi Bulunamadı");
            }
            var kisibolumid = kisibolum.KisiBolumID;
            var kisitoplamtytgirissayisi = _tytSinavGirisTablosuService.TGetList().Where(x=> x.GirenKisiID == id).Count();
            var kisitoplamaytgirissayisi = 0;
            if(kisibolumid ==1)
            {
                kisitoplamaytgirissayisi = _aytsayService.TGetList().Where(x => x.GirenKisiID == id).Count();
            }
            if (kisibolumid == 2)
            {
                kisitoplamaytgirissayisi = _ayteaService.TGetList().Where(x => x.GirenKisiID == id).Count();
            }
            if (kisibolumid == 3)
            {
                kisitoplamaytgirissayisi = _aytsozelService.TGetList().Where(x => x.GirenKisiID == id).Count();
            }
            if (kisibolumid == 4)
            {
                kisitoplamaytgirissayisi = _aytydService.TGetList().Where(x => x.GirenKisiID == id).Count();
            }
            var girisdto = new GirilenSinavSayisiDto();
            girisdto.ToplamAytSayisi = kisitoplamaytgirissayisi;
            girisdto.ToplamTytSayisi = kisitoplamtytgirissayisi;
            return Ok(girisdto);
        }
        [HttpGet]
        [Route("/Sinav/KisiSon4DenemeGet")]
        public IActionResult KisiSon4DenemeGet(int id)
        {
            var kisibolum = _kisiservice.TGetByid(id);
            if (kisibolum == null)
            {
                return BadRequest("Kişi Bulunamadı");
            }

            var kisibolumid = kisibolum.KisiBolumID;

            var kisitytdenemeleri = _tytSinavGirisTablosuService.TGetList()
               .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                .OrderByDescending(x => x.OlusturulmaTarihi)
                .Take(4);

            IEnumerable<AytSayHedef> kisiaytdenemeleri = null;
            // Deneme sonuçlarını tutacak liste
            List<KisiGirilenSon4DenemeDto> son4Denemeler = new List<KisiGirilenSon4DenemeDto>();

            // TYT denemeleri ekle
            foreach (var deneme in kisitytdenemeleri)
            {
                son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                {
                    DenemeTabloID = deneme.TabloID,
                    DenemeTipiID = 0, // TYT tipini temsil eder
                    IconName = "TytIcon",
                    DenemeAdi = deneme.SinavAdi,
                    DenemeDogruSayisi = deneme.TytTurkceDogruSayisi + deneme.TytMatematikDogruSayisi + deneme.TytFenDogruSayisi + deneme.TytSosyalDogruSayisi,
                    DenemeYanlisSayisi = deneme.TytTurkceYanlisSayisi + deneme.TytMatematikYanlisSayisi + deneme.TytFenYanlisSayisi + deneme.TytSosyalYanlisSayisi,
                    DenemeBosSayisi = 0, // Gerekirse hesaplanabilir
                    DenemeGirenKisiID = id,
                    DenemeGirisTarihi = deneme.OlusturulmaTarihi
                });
            }

            // AYT denemelerini ekle
            if (kisibolumid == 1) // SAY
            {
                var aytSayDenemeleri = _aytsayService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytSayDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // SAY tipi
                        IconName = "AytSayIcon",
                        DenemeAdi = deneme.SinavAdi,
                        DenemeDogruSayisi = deneme.AytMatDogruSayisi + deneme.AytFizikDogruSayisi + deneme.AytKimyaDogruSayisi + deneme.AytBiyolojiDogruSayisi,
                        DenemeYanlisSayisi = deneme.AytMatYanlisSayisi + deneme.AytFizikYanlisSayisi + deneme.AytKimyaYanlisSayisi + deneme.AytBiyolojiYanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            else if (kisibolumid == 2) // EA
            {
                var aytEaDenemeleri = _ayteaService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytEaDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // EA tipi
                        DenemeAdi = deneme.SinavAdi,
                        IconName = "AytEAIcon",
                        DenemeDogruSayisi = deneme.AytMatDogruSayisi + deneme.AytEdebiyatDogruSayisi + deneme.AytTarih1DogruSayisi + deneme.AytCografya1DogruSayisi,
                        DenemeYanlisSayisi = deneme.AytMatYanlisSayisi + deneme.AytEdebiyatYanlisSayisi + deneme.AytTarih1YanlisSayisi + deneme.AytCografya1YanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            else if (kisibolumid == 3) // SOZEL
            {
                var aytSozelDenemeleri = _aytsozelService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytSozelDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // SOZEL tipi
                        DenemeAdi = deneme.SinavAdi,
                        IconName = "AytSozelIcon",
                        DenemeDogruSayisi = deneme.AytEdebiyatDogruSayisi + deneme.AytTarih1DogruSayisi + deneme.AytTarih2DogruSayisi + deneme.AytCografya1DogruSayisi + deneme.AytCografya2DogruSayisi + deneme.AytFelsefeDogruSayisi + deneme.AytDinDogruSayisi,
                        DenemeYanlisSayisi = deneme.AytEdebiyatYanlisSayisi + deneme.AytTarih1YanlisSayisi + deneme.AytTarih2YanlisSayisi + deneme.AytCografya1YanlisSayisi + deneme.AytCografya2YanlisSayisi + deneme.AytFelsefeYanlisSayisi + deneme.AytDinYanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            else if (kisibolumid == 4) // DİL
            {
                var aytDilDenemeleri = _aytydService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytDilDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // DİL tipi
                        DenemeAdi = deneme.SinavAdi,
                        IconName = "AytDilIcon",
                        DenemeDogruSayisi = deneme.AytDilDogruSayisi,
                        DenemeYanlisSayisi = deneme.AytDilYanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            var son4SiralanmisDenemeler = son4Denemeler
       .OrderByDescending(x => x.DenemeGirisTarihi)
       .Take(4)
       .ToList();
            // Sonuçları döndür
            return Ok(son4Denemeler);

        }

        [HttpGet]
        [Route("/Sinav/KisiSonDenemelerGet")]
        public IActionResult KisiSonDenemelerGet(int id)
        {
            var kisibolum = _kisiservice.TGetByid(id);
            if (kisibolum == null)
            {
                return BadRequest("Kişi Bulunamadı");
            }

            var kisibolumid = kisibolum.KisiBolumID;

            var kisitytdenemeleri = _tytSinavGirisTablosuService.TGetList()
               .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                .OrderByDescending(x => x.OlusturulmaTarihi)
                .Take(4);

            IEnumerable<AytSayHedef> kisiaytdenemeleri = null;
            // Deneme sonuçlarını tutacak liste
            List<KisiGirilenSon4DenemeDto> son4Denemeler = new List<KisiGirilenSon4DenemeDto>();

            // TYT denemeleri ekle
            foreach (var deneme in kisitytdenemeleri)
            {
                son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                {
                    DenemeTabloID = deneme.TabloID,
                    DenemeTipiID = 0, // TYT tipini temsil eder
                    IconName = "TytIcon",
                    DenemeAdi = deneme.SinavAdi,
                    DenemeDogruSayisi = deneme.TytTurkceDogruSayisi + deneme.TytMatematikDogruSayisi + deneme.TytFenDogruSayisi + deneme.TytSosyalDogruSayisi,
                    DenemeYanlisSayisi = deneme.TytTurkceYanlisSayisi + deneme.TytMatematikYanlisSayisi + deneme.TytFenYanlisSayisi + deneme.TytSosyalYanlisSayisi,
                    DenemeBosSayisi = 0, // Gerekirse hesaplanabilir
                    DenemeGirenKisiID = id,
                    DenemeGirisTarihi = deneme.OlusturulmaTarihi
                });
            }

            // AYT denemelerini ekle
            if (kisibolumid == 1) // SAY
            {
                var aytSayDenemeleri = _aytsayService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytSayDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // SAY tipi
                        IconName = "AytSayIcon",
                        DenemeAdi = deneme.SinavAdi,
                        DenemeDogruSayisi = deneme.AytMatDogruSayisi + deneme.AytFizikDogruSayisi + deneme.AytKimyaDogruSayisi + deneme.AytBiyolojiDogruSayisi,
                        DenemeYanlisSayisi = deneme.AytMatYanlisSayisi + deneme.AytFizikYanlisSayisi + deneme.AytKimyaYanlisSayisi + deneme.AytBiyolojiYanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            else if (kisibolumid == 2) // EA
            {
                var aytEaDenemeleri = _ayteaService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytEaDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // EA tipi
                        IconName = "AytEAIcon",
                        DenemeAdi = deneme.SinavAdi,
                        DenemeDogruSayisi = deneme.AytMatDogruSayisi + deneme.AytEdebiyatDogruSayisi + deneme.AytTarih1DogruSayisi + deneme.AytCografya1DogruSayisi,
                        DenemeYanlisSayisi = deneme.AytMatYanlisSayisi + deneme.AytEdebiyatYanlisSayisi + deneme.AytTarih1YanlisSayisi + deneme.AytCografya1YanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            else if (kisibolumid == 3) // SOZEL
            {
                var aytSozelDenemeleri = _aytsozelService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytSozelDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // SOZEL tipi
                        IconName = "AytSozelIcon",
                        DenemeAdi = deneme.SinavAdi,
                        DenemeDogruSayisi = deneme.AytEdebiyatDogruSayisi + deneme.AytTarih1DogruSayisi + deneme.AytTarih2DogruSayisi + deneme.AytCografya1DogruSayisi + deneme.AytCografya2DogruSayisi + deneme.AytFelsefeDogruSayisi + deneme.AytDinDogruSayisi,
                        DenemeYanlisSayisi = deneme.AytEdebiyatYanlisSayisi + deneme.AytTarih1YanlisSayisi + deneme.AytTarih2YanlisSayisi + deneme.AytCografya1YanlisSayisi + deneme.AytCografya2YanlisSayisi + deneme.AytFelsefeYanlisSayisi + deneme.AytDinYanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            else if (kisibolumid == 4) // DİL
            {
                var aytDilDenemeleri = _aytydService.TGetList()
                    .Where(x => x.GirenKisiID == id && x.SilindiMi == false)
                    .OrderByDescending(x => x.OlusturulmaTarihi)
                    .Take(4);

                foreach (var deneme in aytDilDenemeleri)
                {
                    son4Denemeler.Add(new KisiGirilenSon4DenemeDto
                    {
                        DenemeTabloID = deneme.TabloID,
                        DenemeTipiID = kisibolumid, // DİL tipi
                        IconName = "AytDilIcon",
                        DenemeAdi = deneme.SinavAdi,
                        DenemeDogruSayisi = deneme.AytDilDogruSayisi,
                        DenemeYanlisSayisi = deneme.AytDilYanlisSayisi,
                        DenemeBosSayisi = 0,
                        DenemeGirenKisiID = id,
                        DenemeGirisTarihi = deneme.OlusturulmaTarihi
                    });
                }
            }
            
           
            // Sonuçları döndür
            return Ok(son4Denemeler);

        }
    }
}
