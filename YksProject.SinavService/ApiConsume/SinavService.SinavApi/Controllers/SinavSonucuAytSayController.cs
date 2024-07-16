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
    public class SinavSonucuAytSayController : ControllerBase
    {
        private readonly IAytSayService _AYT;
        private readonly IHelperFunctions _helperFunctions;
        public SinavSonucuAytSayController(IAytSayService aytSayService, IHelperFunctions helperFunctions)
        {
            _AYT = aytSayService;
            _helperFunctions = helperFunctions;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult KisiAytSaySinavGetir(int id)
        {
            var tyt = _AYT.TGetList().Where(x => x.GirenKisiID == id && x.SilindiMi == false);
            return Ok(tyt);
        }
        [HttpPost]
        public IActionResult KisiAytSaySinaviEkle(AytSayGirisTablosu model)
        {
            model.SinavAdi = "SonKoç Ayt Sayısal - " + _helperFunctions.GenerateRandomKey();
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
        public IActionResult KisiAytSayDogruYanlisGir(KisiAytSayDogruYanlisDto model)
        {
            var result = _AYT.TGetByid(model.TabloID);
            if (result.GirenKisiID != model.GirenKisiID)
            {
                return BadRequest("Yetkiniz yoktur");
            }
            result.AytMatDogruSayisi = model.AytMatDogruSayisi;
            result.AytMatYanlisSayisi = model.AytMatYanlisSayisi;
            result.AytMatNetSayisi = _helperFunctions.CalculateNetScore(model.AytMatDogruSayisi, model.AytMatYanlisSayisi);
            result.AytFizikDogruSayisi = model.AytFizikDogruSayisi;
            result.AytFizikYanlisSayisi = model.AytFizikYanlisSayisi;
            result.AytFizikNetSayisi = _helperFunctions.CalculateNetScore(model.AytFizikDogruSayisi, model.AytFizikYanlisSayisi);
            result.AytKimyaDogruSayisi = model.AytKimyaDogruSayisi;
            result.AytKimyaYanlisSayisi = model.AytKimyaYanlisSayisi;
            result.AytKimyaNetSayisi = _helperFunctions.CalculateNetScore(model.AytKimyaDogruSayisi, model.AytKimyaYanlisSayisi);
            result.AytBiyolojiDogruSayisi = model.AytBiyolojiDogruSayisi;
            result.AytBiyolojiYanlisSayisi = model.AytBiyolojiYanlisSayisi;
            result.AytBiyolojiNetSayisi = _helperFunctions.CalculateNetScore(model.AytBiyolojiDogruSayisi, model.AytBiyolojiYanlisSayisi);

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
        public IActionResult KisiAytSayDenemeSureGir(KisiAytSaySureDto model)
        {
            if (model.BitenDersID == 1)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytFizikToplamDakika + value.AytKimyaToplamDakika + value.AytBiyolojiToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytMatToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 2)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytMatToplamDakika + value.AytKimyaToplamDakika + value.AytBiyolojiToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytFizikToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 3)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytMatToplamDakika + value.AytFizikToplamDakika + value.AytBiyolojiToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytKimyaToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 4)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytMatToplamDakika + value.AytFizikToplamDakika + value.AytKimyaToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytBiyolojiToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            return BadRequest("Hatalı bir işlem olmuştur.");
        }


    }
}
