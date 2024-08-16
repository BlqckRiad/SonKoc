using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class GununSozuController : ControllerBase
    {
        private readonly IGununSozuService _gununsozuservice;
        public GununSozuController(IGununSozuService gununSozuService)
        {
            _gununsozuservice = gununSozuService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var sozler = _gununsozuservice.TGetList().Where(X => X.SilindiMi == false);
            return Ok(sozler);
        }
        [HttpPost]
        public IActionResult Add(GununSozuAddDto model)
        {
            var gununsozu = new GununSozu();
            gununsozu.OlusturulmaTarihi = DateTime.Now;
            gununsozu.OlusturanKisiID = model.OlusturanKisiID;
            gununsozu.Soz = model.Soz;
            _gununsozuservice.TAdd(gununsozu);
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(DeleteDto model)
        {
            var silineceksoz = _gununsozuservice.TGetByid(model.TabloID);
            silineceksoz.SilindiMi = true;
            silineceksoz.SilenKisiID = model.SilenKisiID;
            silineceksoz.SilinmeTarihi = DateTime.Now;
            _gununsozuservice.TUpdate(silineceksoz);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetWithID(int id)
        {
            var soz = _gununsozuservice.TGetByid(id);
            return Ok(soz);
        }
        [HttpPost]
        public IActionResult GununSozuUpdate(GununSozuUpdateDto model)
        {
            var gununsozu = _gununsozuservice.TGetByid(model.TabloID);
            gununsozu.Soz = model.Soz;
            gununsozu.GuncellenmeTarihi = DateTime.Now;
            gununsozu.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _gununsozuservice.TUpdate(gununsozu);
            return Ok();
        }
    }
}
