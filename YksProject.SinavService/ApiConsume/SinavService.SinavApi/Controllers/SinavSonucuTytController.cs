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
    public class SinavSonucuTytController : ControllerBase
    {
        private readonly ITytSinavGirisTablosuService _tyt;
        private readonly IHelperFunctions _helperFunctions;
        public SinavSonucuTytController(ITytSinavGirisTablosuService tytSinavGirisTablosuService , IHelperFunctions helperFunctions)
        {
            _tyt = tytSinavGirisTablosuService;
            _helperFunctions = helperFunctions;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult KisiTytSinaviGetir(int id)
        {
            var tyt = _tyt.TGetList().Where(x => x.GirenKisiID == id && x.SilindiMi == false);
            return Ok(tyt);
        }
        [HttpPost]
        public IActionResult KisiTytSinaviEkle(TytSinavGirisTablosu model)
        {
            model.SinavAdi = "SonKoç Tyt - " + _helperFunctions.GenerateRandomKey();
            model.BaslangicZamani = DateTime.Now;
            model.OlusturulmaTarihi = DateTime.Now;
            _tyt.TAdd(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult DenemeAdiGuncelle(DenemeAdiGuncelleDto model)
        {
            var result = _tyt.TGetByid(model.DenemeID);
            result.SinavAdi = model.DenemeAdi;
            _tyt.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult KisiTytDogruYanlisGir(KisiTytDogruYanlisDto model)
        {
            var result = _tyt.TGetByid(model.TabloID);
            if (result.GirenKisiID != model.GirenKisiID)
            {
                return BadRequest("Yetkiniz yoktur");
            }
            result.TytTurkceDogruSayisi = model.TytTurkceDogruSayisi;
            result.TytTurkceYanlisSayisi = model.TytTurkceYanlisSayisi;
            result.TytTurkceNetSayisi = _helperFunctions.CalculateNetScore(model.TytTurkceDogruSayisi, model.TytTurkceYanlisSayisi);
            result.TytMatematikDogruSayisi = model.TytMatematikDogruSayisi;
            result.TytMatematikYanlisSayisi = model.TytMatematikYanlisSayisi;
            result.TytMatematikNetSayisi = _helperFunctions.CalculateNetScore(model.TytMatematikDogruSayisi, model.TytMatematikYanlisSayisi);
            result.TytFenDogruSayisi = model.TytFenDogruSayisi;
            result.TytFenYanlisSayisi = model.TytFenYanlisSayisi;
            result.TytFenNetSayisi = _helperFunctions.CalculateNetScore(model.TytFenDogruSayisi, model.TytFenYanlisSayisi);
            result.TytSosyalDogruSayisi = model.TytSosyalDogruSayisi;
            result.TytSosyalYanlisSayisi = model.TytSosyalYanlisSayisi;
            result.TytSosyalNetSayisi = _helperFunctions.CalculateNetScore(model.TytSosyalDogruSayisi, model.TytSosyalYanlisSayisi);

            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GirenKisiID;
            _tyt.TUpdate(result);
            return Ok();
        }

        [HttpPost]
        public IActionResult KisiSinaviBitir(SinavBitirDto model)
        {
            var result = _tyt.TGetByid(model.BitecekSinavID);
            result.BitisTarihi = DateTime.Now;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.KisiID;
            _tyt.TUpdate(result);
            return Ok();
        }

        [HttpPost]
        public IActionResult KisiDenemeSureGir(KisiDenemeSureDto model)
        {
            if (model.BitenDersID == 1)
            {
                var value = _tyt.TGetByid(model.TabloID);
                var deger = value.TytFenToplamDakika + value.TytMatematikToplamDakika + value.TytSosyalToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.TytTurkceToplamDakika = farkdakika - deger;
                _tyt.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 2)
            {
                var value = _tyt.TGetByid(model.TabloID);
                var deger = value.TytFenToplamDakika + value.TytTurkceToplamDakika + value.TytSosyalToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.TytMatematikToplamDakika = farkdakika - deger;
                _tyt.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 3)
            {
                var value = _tyt.TGetByid(model.TabloID);
                var deger = value.TytFenToplamDakika + value.TytMatematikToplamDakika + value.TytTurkceToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.TytSosyalToplamDakika = farkdakika - deger;
                _tyt.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 4)
            {
                var value = _tyt.TGetByid(model.TabloID);
                var deger = value.TytTurkceToplamDakika + value.TytMatematikToplamDakika + value.TytSosyalToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.TytFenToplamDakika = farkdakika - deger;
                _tyt.TUpdate(value);
                return Ok();
            }
            return BadRequest("Hatalı bir işlem olmuştur.");
        }
        
        
    }
}
