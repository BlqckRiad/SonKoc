using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class KonularController : ControllerBase
    {
        private readonly IKonularService _konularService;

        public KonularController(IKonularService konularService)
        {
            _konularService = konularService;
        }
        [HttpGet]
        public ActionResult<List<Konular>> ListKonular()
        {
            var result = _konularService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }


        [HttpPost("Silme")]
        public IActionResult DeleteKonular(DeleteDto model)
        {
            var values = _konularService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _konularService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateKonular(Konular model)
        {
            var result = _konularService.TGetByid(model.TabloID);
            result.KonuAdi = model.KonuAdi;
            result.KonuDersID = model.KonuDersID;
            result.Konu1SeneSoruSayisi = model.Konu1SeneSoruSayisi;
            result.Konu2SeneSoruSayisi = model.Konu2SeneSoruSayisi;
            result.Konu3SeneSoruSayisi = model.Konu3SeneSoruSayisi;
            result.KonuAciklamasi = model.KonuAciklamasi;
            result.KonuAciklamasiYapanKisi = model.KonuAciklamasiYapanKisi;
            result.KonuAciklamasiYapanKisiRolu = model.KonuAciklamasiYapanKisiRolu;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _konularService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddKonular(Konular model)
        {
            _konularService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<Konular> GetKonular(int id)
        {
            var result = _konularService.TGetByid(id);
            return result;
        }
    }
}
