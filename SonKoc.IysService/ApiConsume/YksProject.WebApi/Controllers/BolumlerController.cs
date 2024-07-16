using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BolumlerController : ControllerBase
    {
        private readonly IBolumlerService _bolumlerService;
        public BolumlerController(IBolumlerService bolumlerService)
        {
            _bolumlerService = bolumlerService;
        }
        [HttpGet]
        public ActionResult<List<Bolumler>> ListBolum()
        {
            var result = _bolumlerService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }


        [HttpPost("Silme")]
        public IActionResult DeleteBolum(DeleteDto model)
        {
            var values = _bolumlerService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _bolumlerService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBolum(Bolumler model)
        {
            var result = _bolumlerService.TGetByid(model.TabloID);
            result.BolumAdi = model.BolumAdi;
            result.BolumAdKodu = model.BolumAdKodu;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _bolumlerService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddBolum(Bolumler model)
        {
            _bolumlerService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<Bolumler> GetBolum(int id)
        {
            var result = _bolumlerService.TGetByid(id);
            return result;
        }
    }
}
