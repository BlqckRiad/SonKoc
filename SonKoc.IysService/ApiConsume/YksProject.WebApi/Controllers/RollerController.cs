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
    public class RollerController : ControllerBase
    {
        private readonly IRollerService _rollerService;
        public RollerController(IRollerService rollerService)
        {
            _rollerService = rollerService;
        }
        [HttpGet]
        public IActionResult ListRoller()
        {
            var result = _rollerService.TGetList();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoller(int id)
        {
            var values = _rollerService.TGetByid(id);
            values.SilindiMi = true;
            values.SilinmeTarihi = DateTime.Now;
            values.SilenKisiID = 1; //Değiştirelecek.
            _rollerService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoller(Roller model)
        {
          
            model.GuncellenmeTarihi = DateTime.Now;
            model.GuncelleyenKisiID = 1; //Değiştirelecek.
            _rollerService.TUpdate(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddRoller(Roller model)
        {
            model.OlusturulmaTarihi = DateTime.Now;
            model.OlusturanKisiID = 1; // Değiştirelecek.
            model.SilindiMi = false;

            _rollerService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        
        public IActionResult GetRoller(int id)
        {
            var result = _rollerService.TGetByid(id);
            return Ok(result);
        }
    }
}

