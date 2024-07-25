using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
using SinavService.EntityLayer.Concrete;
using SinavService.SinavApi.Service;
using System;
using System.Linq;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class SinavSonucuAytYdController : ControllerBase
    {
        private readonly IAytDilService _AYT;
        private readonly IHelperFunctions _helperFunctions;
        public SinavSonucuAytYdController(IAytDilService ayteaService, IHelperFunctions helperFunctions)
        {
            _AYT = ayteaService;
            _helperFunctions = helperFunctions;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult KisiAytYdSinavGetir(int id)
        {
            var tyt = _AYT.TGetList().Where(x => x.GirenKisiID == id && x.SilindiMi == false);
            return Ok(tyt);
        }
        [HttpPost]
        public IActionResult KisiAytDilSinaviEkle(AytYDGirisTablosu model)
        {
            model.SinavAdi = "SonKoç Ayt Dil - " + _helperFunctions.GenerateRandomKey();
            model.BaslangicZamani = DateTime.Now;
            model.OlusturulmaTarihi = DateTime.Now;
            _AYT.TAdd(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult DenemeAdiGuncelle(DenemeAdiGuncelleDto model)
        {
            var result = _AYT.TGetByid(model.DenemeID);
            result.SinavAdi = model.DenemeAdi;
            _AYT.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult KisiAytDilDogruYanlisDto(KisiAytDilDogruYanlisDto model)
        {
            var result = _AYT.TGetByid(model.TabloID);
            if (result.GirenKisiID != model.GirenKisiID)
            {
                return BadRequest("Yetkiniz yoktur");
            }
            result.AytDilDogruSayisi = model.AytDilDogruSayisi;
            result.AytDilYanlisSayisi = model.AytDilYanlisSayisi;
            result.AytDilNetSayisi = _helperFunctions.CalculateNetScore(model.AytDilDogruSayisi, model.AytDilYanlisSayisi);
            

            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GirenKisiID;
            _AYT.TUpdate(result);
            return Ok();
        }

        [HttpPost]
        public IActionResult KisiSinaviBitir(SinavBitirDto model)
        {
            var result = _AYT.TGetByid(model.BitecekSinavID);
            result.BitisTarihi = DateTime.Now;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.KisiID;
            _AYT.TUpdate(result);
            return Ok();
        }

        [HttpPost]
        public IActionResult KisiAytDilDenemeSureGir(KisiAytDilSureDto model)
        {
            if (model.BitenDersID == 1)
            {
                var value = _AYT.TGetByid(model.TabloID);                
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytDilToplamDakika = farkdakika;
                _AYT.TUpdate(value);
                return Ok();
            }
           
            return BadRequest("Hatalı bir işlem olmuştur.");
        }
    }
}
