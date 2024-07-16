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
    public class DerslerController : ControllerBase
    {
        private readonly IDerslerService _derslerService;
        public DerslerController(IDerslerService derslerService)
        {
            _derslerService = derslerService;
        }
        [HttpGet]
        public ActionResult<List<Dersler>> ListDers()
        {
            var result = _derslerService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }

        [HttpPost("Silme")]
        public IActionResult DeleteDers(DeleteDto model)
        {
            var values = _derslerService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _derslerService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDers(Dersler model)
        {
            var result = _derslerService.TGetByid(model.TabloID);
            result.DersBolumID = model.DersBolumID;
            result.DersAdi = model.DersAdi;
           
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _derslerService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddDers(Dersler model)
        {
            _derslerService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<Dersler> GetDers(int id)
        {
            var result = _derslerService.TGetByid(id);
            return result;
        }
    }
}
