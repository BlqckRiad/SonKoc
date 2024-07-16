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
    public class YapilacaklarController : ControllerBase
    {
        private readonly IYapilacaklarService _yapilacaklarService;
        public YapilacaklarController(IYapilacaklarService yapilacaklarService)
        {
            _yapilacaklarService = yapilacaklarService;
        }
        [HttpGet]
        public IActionResult ListYapilacaklar()
        {
            var result = _yapilacaklarService.TGetList();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteYapilacaklar(int id)
        {
            var values = _yapilacaklarService.TGetByid(id);
            _yapilacaklarService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateYapilacaklar(Yapilacaklar model)
        {
            model.GorevYapilmaTarihi = DateTime.Now;
            _yapilacaklarService.TUpdate(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddYapilacaklar(Yapilacaklar model)
        {
            _yapilacaklarService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetYapilacaklar(int id)
        {
            var result = _yapilacaklarService.TGetByid(id);
            return Ok(result);
        }
    }
}
