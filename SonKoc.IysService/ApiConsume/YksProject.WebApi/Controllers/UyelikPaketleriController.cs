using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UyelikPaketleriController : ControllerBase
    {
        private readonly IUyelikPaketleriService _uyelikPaketleriService;
        public UyelikPaketleriController(IUyelikPaketleriService uyelikPaketleri)
        {
            _uyelikPaketleriService = uyelikPaketleri;
        }
        [HttpGet]
        public ActionResult<List<UyelikPaketleri>> ListPaket()
        {
            var result = _uyelikPaketleriService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }


        [HttpPost("Silme")]
        public IActionResult DeletePaket(DeleteDto model)
        {
            var values = _uyelikPaketleriService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _uyelikPaketleriService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdatePaket(UyelikPaketleri model)
        {
            var result = _uyelikPaketleriService.TGetByid(model.TabloID);
            result.PaketAdi = model.PaketAdi;
            result.PaketAciklamasi = model.PaketAciklamasi;
            result.PaketImageID = model.PaketImageID;
            result.PaketImageUrl = model.PaketImageUrl;
            result.PaketUcreti = model.PaketUcreti;
            result.PaketIndirimOrani = model.PaketIndirimOrani;
            result.PaketUyeTipiID = model.PaketUyeTipiID;
            result.PaketUyeSayısı = model.PaketUyeSayısı;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _uyelikPaketleriService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddPaket(UyelikPaketleri model)
        {
            _uyelikPaketleriService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<UyelikPaketleri> GetPaket(int id)
        {
            var result = _uyelikPaketleriService.TGetByid(id);
            if(result.SilindiMi==true)
            {
                return null;
            }
            return result;
        }
    }
}
