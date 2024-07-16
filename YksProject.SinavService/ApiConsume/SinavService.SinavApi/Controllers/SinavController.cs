using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
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
        public SinavController(ISinavService sinavService)
        {
            _sinavservice = sinavService;
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
    }
}
