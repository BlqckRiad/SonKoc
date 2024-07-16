using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;
using YksProject.WebApi.Service;

namespace YksProject.YksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReferanslarimizController : ControllerBase
    {
        private readonly IReferanslarimizService _referanslarimizService;
        private readonly ITokenCreateService _medyaKutuphanesiService;
        public ReferanslarimizController(IReferanslarimizService referanslarimizService , ITokenCreateService medyaKutuphanesiService)
        {
            _referanslarimizService = referanslarimizService;
            _medyaKutuphanesiService = medyaKutuphanesiService;
        }
        [HttpGet]
        public ActionResult<List<Referanslarimiz>> ListReferanslarimiz()
        {
            var result = _referanslarimizService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }
        [HttpPost("Silme")]
        public IActionResult DeleteReferanslarimiz(DeleteDto model)
        {
            var values = _referanslarimizService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _medyaKutuphanesiService.DeleteMedyaWithUrl(values.ReferansImage);
            _referanslarimizService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateReferanslarimiz(Referanslarimiz model)
        {
            var result = _referanslarimizService.TGetByid(model.TabloID);
            result.ReferansAdi = model.ReferansAdi;
            result.ReferansAciklamasi = model.ReferansAciklamasi;
            result.ReferansImage = model.ReferansImage;
            result.ReferansPuani = model.ReferansPuani;
            result.ReferansRolu = model.ReferansRolu;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _referanslarimizService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddReferanslarimiz(Referanslarimiz model)
        {
            _referanslarimizService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetReferanslarimiz(int id)
        {
            var result = _referanslarimizService.TGetByid(id);
            return Ok(result);
        }
    }
}
