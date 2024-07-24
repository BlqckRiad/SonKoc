using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.EntityLayer.Concrete;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KisiTytHedefiController : ControllerBase
    {
        private readonly ITytHedefService _tytHedefService;
        public KisiTytHedefiController(ITytHedefService tytHedefService)
        {
            _tytHedefService = tytHedefService;
        }
        [HttpPost]
        public IActionResult KisiTytHedefiEkle (TytHedef model)
        {
            _tytHedefService.TAdd(model);
            return Ok();
        }
        [HttpGet]
        public IActionResult TytHedefGetWithTabloID (int id)
        {
            var result = _tytHedefService.TGetByid (id);
            return Ok(result);
        }
    }
}
