using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using YksProject.BusinessLayer.Abstract;
using YksProject.EntityLayer.Concrete;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MedyaKutuphanesiController : ControllerBase
    {
        private readonly IMedyaKutuphanesiService _medyaKutuphanesiService;
        public MedyaKutuphanesiController(IMedyaKutuphanesiService medyaKutuphanesiService)
        {
            _medyaKutuphanesiService = medyaKutuphanesiService;
        }
        [HttpGet]
        public IActionResult ListMedyaKutuphanesi()
        {
            var result = _medyaKutuphanesiService.TGetList();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMedyaKutuphanesi(int id)
        {
            var values = _medyaKutuphanesiService.TGetByid(id);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            _medyaKutuphanesiService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMedyaKutuphanesi(MedyaKutuphanesi model)
        {
            _medyaKutuphanesiService.TUpdate(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddMedyaKutuphanesi(MedyaKutuphanesi model)
        {
            _medyaKutuphanesiService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMedyaKutuphanesi(int id)
        {
            var result = _medyaKutuphanesiService.TGetByid(id);
            return Ok(result);
        }

       
    }
}
