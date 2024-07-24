using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
using SinavService.EntityLayer.Concrete;
using System.Linq;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HedefController : ControllerBase
    {
        private readonly IHedefGenelTanimlariService _genelTanimlariService;
        private readonly ITytHedefService _tytHedefService;
        private readonly IAytSayService _aytSayService;
        private readonly IAytSozelService _aytSozelService;
        private readonly IAytEaService _aytEaService;
        private readonly IAytYdHedefService _aytYdHedefService;
        public HedefController(IHedefGenelTanimlariService hedefGenelTanimlariService, ITytHedefService tytHedefService, IAytSayService aytSayService
            , IAytSozelService aytSozelService, IAytEaService aytEaService, IAytYdHedefService aytYdHedefService)
        {
            _genelTanimlariService = hedefGenelTanimlariService;
            _tytHedefService = tytHedefService;
            _aytEaService = aytEaService;
            _aytSayService = aytSayService;
            _aytSozelService = aytSozelService;
            _aytYdHedefService = aytYdHedefService;
        }
        [HttpGet]
        public IActionResult KisiTytHedefiGetir(int id)
        {
            var kisitytid = _genelTanimlariService.GetHedefWithUserID(id).HedefTytID;
            var result = _tytHedefService.TGetByid(kisitytid);
            return Ok(result);           
        }
        [HttpPost]
        public IActionResult KisiAytHedefiGetir (KisiAytHedefDto model)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(model.KisiID).HedefAytID;
            if(model.KisiBolumID == 0)
            {
                return BadRequest("Lütfen Hangi Bölüm Öğrencisi Olduğunuzu Belirtiniz.");
            }
            if(model.KisiBolumID == 1) // Sayısal ise 
            {
                return Ok(_aytSayService.TGetByid(kisiaytid));
            }
            if (model.KisiBolumID == 2) 
            {
                return Ok(_aytEaService.TGetByid(kisiaytid));
            }
            if (model.KisiBolumID == 3)
            {
                return Ok(_aytSozelService.TGetByid(kisiaytid));
            }
            if (model.KisiBolumID == 4)
            {
                return Ok(_aytYdHedefService.TGetByid(kisiaytid));
            }
           return NotFound("Öğrenci Bölüm Değeri Hatalı");
        }
        [HttpGet]
        public IActionResult KisiGenelHedefleriniGetirWithHedefid(int id)
        {
            var kisigenelhedef = _genelTanimlariService.TGetByid(id);
            return Ok(kisigenelhedef);
        }
        [HttpGet]
        public IActionResult KisiGenelHedefleriniGetirWithKisiID(int id)
        {
            var kisigenelhedef = _genelTanimlariService.GetHedefWithUserID(id);
            return Ok(kisigenelhedef);
        }
        [HttpPost]
        public IActionResult KisiHedefEkle(HedefGenelTanimlari model)
        {
            _genelTanimlariService.TAdd(model);
            return Ok();
        }
    }
}
