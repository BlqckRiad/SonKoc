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
    public class SinavSonucuAytSozelController : ControllerBase
    {
        private readonly IAytSozelService _AYT;
        private readonly IHelperFunctions _helperFunctions;
        public SinavSonucuAytSozelController(IAytSozelService aytsozelService, IHelperFunctions helperFunctions)
        {
            _AYT = aytsozelService;
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
        public IActionResult KisiAytEaSinaviEkle(AytSozelGirisTablosu model)
        {
            model.SinavAdi = "SonKoç Ayt Sözel - " + _helperFunctions.GenerateRandomKey();
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
        public IActionResult KisiAytSozelDogruYanlisDto(KisiAytSozelDogruYanlisDto model)
        {
            var result = _AYT.TGetByid(model.TabloID);
            if (result.GirenKisiID != model.GirenKisiID)
            {
                return BadRequest("Yetkiniz yoktur");
            }
       
            result.AytEdebiyatDogruSayisi = model.AytEdebiyatDogruSayisi;
            result.AytEdebiyatYanlisSayisi = model.AytEdebiyatYanlisSayisi;
            result.AytEdebiyatNetSayisi = _helperFunctions.CalculateNetScore(model.AytEdebiyatDogruSayisi, model.AytEdebiyatYanlisSayisi);
            result.AytTarih1DogruSayisi = model.AytTarih1DogruSayisi;
            result.AytTarih1YanlisSayisi = model.AytTarih1YanlisSayisi;
            result.AytTarih1NetSayisi = _helperFunctions.CalculateNetScore(model.AytTarih1DogruSayisi, model.AytTarih1YanlisSayisi);
            result.AytCografya1DogruSayisi = model.AytCografya1DogruSayisi;
            result.AytCografya1YanlisSayisi = model.AytCografya1YanlisSayisi;
            result.AytCografya1NetSayisi = _helperFunctions.CalculateNetScore(model.AytCografya1DogruSayisi, model.AytCografya1YanlisSayisi);

            result.AytTarih2DogruSayisi = model.AytTarih2DogruSayisi;
            result.AytTarih2YanlisSayisi = model.AytTarih2YanlisSayisi;
            result.AytTarih2NetSayisi = _helperFunctions.CalculateNetScore(model.AytTarih2DogruSayisi, model.AytTarih2YanlisSayisi);
            result.AytCografya2DogruSayisi = model.AytCografya2DogruSayisi;
            result.AytCografya2YanlisSayisi = model.AytCografya2YanlisSayisi;
            result.AytCografya2NetSayisi = _helperFunctions.CalculateNetScore(model.AytCografya2DogruSayisi, model.AytCografya2YanlisSayisi);
            result.AytFelsefeDogruSayisi = model.AytFelsefeDogruSayisi;
            result.AytFelsefeYanlisSayisi = model.AytFelsefeYanlisSayisi;
            result.AytFelsefeNetSayisi = _helperFunctions.CalculateNetScore(model.AytFelsefeDogruSayisi, model.AytFelsefeYanlisSayisi);
            result.AytDinDogruSayisi = model.AytDinDogruSayisi;
            result.AytDinYanlisSayisi = model.AytDinYanlisSayisi;
            result.AytDinNetSayisi = _helperFunctions.CalculateNetScore(model.AytDinDogruSayisi, model.AytDinYanlisSayisi);

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
        public IActionResult KisiAytSozelDenemeSureGir(KisiAytSozelSureDto model)
        {
            if (model.BitenDersID == 1)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika + value.AytTarih2ToplamDakika + 
                    value.AytCografya2ToplamDakika + value.AytFelsefeToplamDakika + value.AytDinToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytEdebiyatToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 2)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytCografya1ToplamDakika + value.AytTarih2ToplamDakika +
                         value.AytCografya2ToplamDakika + value.AytFelsefeToplamDakika + value.AytDinToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytTarih1ToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 3)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytTarih1ToplamDakika + value.AytTarih2ToplamDakika +
                         value.AytCografya2ToplamDakika + value.AytFelsefeToplamDakika + value.AytDinToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytCografya1ToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 4)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika +
                           value.AytCografya2ToplamDakika + value.AytFelsefeToplamDakika + value.AytDinToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytTarih2ToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 5)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika +
                          value.AytTarih2ToplamDakika + value.AytFelsefeToplamDakika + value.AytDinToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytCografya2ToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 6)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika +
                          value.AytTarih2ToplamDakika + value.AytCografya2ToplamDakika + value.AytDinToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytFelsefeToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            if (model.BitenDersID == 7)
            {
                var value = _AYT.TGetByid(model.TabloID);
                var deger = value.AytEdebiyatToplamDakika + value.AytTarih1ToplamDakika + value.AytCografya1ToplamDakika +
                            value.AytTarih2ToplamDakika + value.AytCografya2ToplamDakika + value.AytFelsefeToplamDakika;
                var suankizaman = DateTime.Now;
                var sınavgiriszamani = value.BaslangicZamani;
                var farkdakika = _helperFunctions.CalculateDifferenceInMinutes(suankizaman, sınavgiriszamani);
                value.AytDinToplamDakika = farkdakika - deger;
                _AYT.TUpdate(value);
                return Ok();
            }
            return BadRequest("Hatalı bir işlem olmuştur.");
        }
    }
}
