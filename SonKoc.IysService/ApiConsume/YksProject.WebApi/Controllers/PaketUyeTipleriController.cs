using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;
using System.Linq;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaketUyeTipleriController : ControllerBase
    {
        private readonly IPaketUyeTipleriService _uyelikPaketleriService;
        public PaketUyeTipleriController(IPaketUyeTipleriService uyelikPaketleri)
        {
            _uyelikPaketleriService = uyelikPaketleri;
        }
        [HttpGet]
        public ActionResult<List<PaketUyeTipleri>> ListPaketUyeTipleri()
        {
            var result = _uyelikPaketleriService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }


        [HttpPost("Silme")]
        public IActionResult DeletePaketUyeTipleri(DeleteDto model)
        {
            var values = _uyelikPaketleriService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _uyelikPaketleriService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdatePaketUyeTiplerit(PaketUyeTipleri model)
        {
            var result = _uyelikPaketleriService.TGetByid(model.TabloID);
            result.UyeTipiAdi = model.UyeTipiAdi;
            result.UyeTipiAciklamasi = model.UyeTipiAciklamasi;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _uyelikPaketleriService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddPaketUyeTipleri(PaketUyeTipleri model)
        {
            _uyelikPaketleriService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<PaketUyeTipleri> GetPaketUyeTipleri(int id)
        {
            var result = _uyelikPaketleriService.TGetByid(id);
            if (result.SilindiMi == true)
            {
                return null;
            }
            return result;
        }
    }
}
