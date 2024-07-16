using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
using SinavService.EntityLayer.Concrete;
using System;
using System.Linq;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SinavTipleriController : ControllerBase
    {
        private readonly ISinavTipleriService _sinavTipleriService;
        public SinavTipleriController(ISinavTipleriService sinavTipleriService)
        {
            _sinavTipleriService = sinavTipleriService; 
        }

        [HttpGet]
        [Route("/SinavTipleri/SinavTipleriGetir")]
        public IActionResult SinavTipleriGetir()
        {
            var result = _sinavTipleriService.TGetList().Where(x=> x.SilindiMi == false);
            return Ok(result);
        }
        [HttpGet]
        [Route("/SinavTipleri/SinavTipleriGetir/{id}")]
        public IActionResult SinavTipleriGetir(int id)
        {
            var result = _sinavTipleriService.TGetByid(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("/SinavTipleri/SinavTipiEkle")]
        public IActionResult SinavTipiEkle(SinavTipleri model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            _sinavTipleriService.TAdd(model);
            return Ok();
        }
        [HttpPost]
        [Route("/SinavTipleri/SinavTipiGuncelle")]
        public IActionResult SinavTipiGuncelle(SinavTipleriUpdateDto model)
        {
            var result = _sinavTipleriService.TGetByid(model.TabloID);
            if(result == null)
            {
                return BadRequest("Sınav Tipi Bulunamadı !!");
            }
            result.SinavTipiAdi = model.SinavTipiAdi;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            result.GuncellenmeTarihi = DateTime.Now;
            _sinavTipleriService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        [Route("/SinavTipleri/SinavTipiSil")]
        public IActionResult SinavTipiSil(DeleteDto model)
        {
           var result = _sinavTipleriService.TGetByid(model.TabloID);
            result.SilindiMi = true;
            result.SilenKisiID = model.SilenKisiID;
            result.SilinmeTarihi = DateTime.Now;
            _sinavTipleriService.TUpdate(result);
            return Ok();
        }
    }
}
