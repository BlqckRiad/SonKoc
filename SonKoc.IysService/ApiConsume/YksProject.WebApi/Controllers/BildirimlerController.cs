using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BildirimlerController : ControllerBase
    {
        private readonly IBildirimlerService _bildirimlerService;
        public BildirimlerController(IBildirimlerService bildirimlerService)
        {
            _bildirimlerService = bildirimlerService;
        }
        [HttpGet("alici/{id}")]
        public IActionResult ListBildirimlerAlici(int id)
        {
            var result = _bildirimlerService.TGetList()
                   .Where(x => (x.AliciKisiID == id || x.AliciKisiID == 0) && x.SilenKisiID != id);

            return Ok(result);
        }

        [HttpGet("gonderici/{id}")]
        public IActionResult ListBildirimlerGonderici(int id)
        {
            var result = _bildirimlerService.TGetList().Where(x => x.GonderenKisiID == id && x.SilenKisiID != id);
            return Ok(result);
        }
        [HttpGet("deleted/{id}")]
        public IActionResult ListBildirimlerDeleted(int id)
        {
            var result = _bildirimlerService.TGetList()
                .Where(x => (x.GonderenKisiID == id && x.SilenKisiID == id) || (x.AliciKisiID == id && x.SilenKisiID == id));
            return Ok(result);
        }

        [HttpPost("Silme")]
        public IActionResult DeleteBildirim(DeleteDto model)
        {
            var values = _bildirimlerService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _bildirimlerService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBildirim(Bildirimler model)
        {
            var result = _bildirimlerService.TGetByid(model.TabloID);
            result.BildirimAciklamasi = model.BildirimAciklamasi;
            result.BildirimBasligi = model.BildirimBasligi;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _bildirimlerService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddBildirim(Bildirimler model)
        {
            _bildirimlerService.TAdd(model);
            return Ok();    
        }
        [HttpGet("{id}")]
        public ActionResult<Bildirimler> GetBildirim(int id)
        {
            var result = _bildirimlerService.TGetByid(id);
            result.BildirimAliciOkuduMu = true;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = 0;
            _bildirimlerService.TUpdate(result);
            return result;
        }       
    }
}
