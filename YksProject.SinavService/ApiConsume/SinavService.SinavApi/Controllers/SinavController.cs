using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
using SinavService.DtoLayer.DtosForUI;
using SinavService.EntityLayer.Concrete;
using System;
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
    }
}
