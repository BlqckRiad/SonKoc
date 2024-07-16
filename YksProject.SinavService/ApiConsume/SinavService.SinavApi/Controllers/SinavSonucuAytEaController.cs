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
    public class SinavSonucuAytEaController : ControllerBase
    {
        private readonly IAytEaService _AYT;
        private readonly IHelperFunctions _helperFunctions;
        public SinavSonucuAytEaController(IAytEaService ayteaService, IHelperFunctions helperFunctions)
        {
            _AYT = ayteaService;
            _helperFunctions = helperFunctions;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult KisiAytEaSinavGetir(int id)
        {
            var tyt = _AYT.TGetList().Where(x => x.GirenKisiID == id && x.SilindiMi == false);
            return Ok(tyt);
        }
        [HttpPost]
        public IActionResult KisiAytEaSinaviEkle(AytEaGirisTablosu model)
        {
            model.SinavAdi = "SonKoç Ayt EA - " + _helperFunctions.GenerateRandomKey();
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
        public IActionResult KisiAytEaDogruYanlisDto(KisiAytEaDogruYanlisDto model)
        {
            var result = _AYT.TGetByid(model.TabloID);
            if (result.GirenKisiID != model.GirenKisiID)
            {
                return BadRequest("Yetkiniz yoktur");
            }
            result.AytMatDogruSayisi = model.AytMatDogruSayisi;
            result.AytMatYanlisSayisi = model.AytMatYanlisSayisi;
            result.AytMatNetSayisi = _helperFunctions.CalculateNetScore(model.AytMatDogruSayisi, model.AytMatYanlisSayisi);
            result.AytEdebiyatDogruSayisi = model.AytEdebiyatDogruSayisi;
            result.AytEdebiyatYanlisSayisi = model.AytEdebiyatYanlisSayisi;
            result.AytEdebiyatNetSayisi = _helperFunctions.CalculateNetScore(model.AytEdebiyatDogruSayisi, model.AytEdebiyatYanlisSayisi);
            result.AytTarih1DogruSayisi = model.AytTarih1DogruSayisi;
            result.AytTarih1YanlisSayisi = model.AytTarih1YanlisSayisi;
            result.AytTarih1NetSayisi = _helperFunctions.CalculateNetScore(model.AytTarih1DogruSayisi, model.AytTarih1YanlisSayisi);
            result.AytCografya1DogruSayisi = model.AytCografya1DogruSayisi;
            result.AytCografya1YanlisSayisi = model.AytCografya1YanlisSayisi;
            result.AytCografya1NetSayisi = _helperFunctions.CalculateNetScore(model.AytCografya1DogruSayisi, model.AytCografya1YanlisSayisi);

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
        public IActionResult KisiAytEaDenemeSureGir(KisiAytEaSureDto model)
        {
            if (model.BitenDersID == 1)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika;
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
                var deger = value.AytMatToplamDakika + value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytEdebiyatToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 3)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytMatToplamDakika + value.AytEdebiyatToplamDakika + value.AytCografya1ToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytTarih1ToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 4)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytMatToplamDakika + value.AytTarih1ToplamDakika + value.AytEdebiyatToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytCografya1ToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            return BadRequest("Hatalı bir işlem olmuştur.");
        }
    }
}
