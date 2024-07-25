using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.Dtos;
using SinavService.DtoLayer.HedefDtos;
using SinavService.EntityLayer.Concrete;
using System;
using System.Linq;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HedefController : ControllerBase
    {
        private readonly IHedefGenelTanimlariService _genelTanimlariService;
        private readonly ITytHedefService _tytHedefService;
        private readonly IAytSayHedefService _aytSayService;
        private readonly IAytSozelHedefService _aytSozelService;
        private readonly IAytEaHedefService _aytEaService;
        private readonly IAytYdHedefService _aytYdHedefService;
        public HedefController(IHedefGenelTanimlariService hedefGenelTanimlariService, ITytHedefService tytHedefService, IAytSayHedefService aytSayService
            , IAytSozelHedefService aytSozelService, IAytEaHedefService aytEaService, IAytYdHedefService aytYdHedefService)
        {
            _genelTanimlariService = hedefGenelTanimlariService;
            _tytHedefService = tytHedefService;
            _aytEaService = aytEaService;
            _aytSayService = aytSayService;
            _aytSozelService = aytSozelService;
            _aytYdHedefService = aytYdHedefService;
        }
        #region Genel
        [HttpGet]
        public IActionResult KisiHedefGenelGet(int id)
        {           
            var result = _genelTanimlariService.GetHedefWithUserID(id);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult HedefGetWithID (int id)
        {
            var result = _genelTanimlariService.TGetByid(id);
            if(result ==null)
            {
                return NotFound();
            }
            return Ok(result);
        }        
        [HttpPost]
        public IActionResult KisiHedefOlusturSistem(KisiAytHedefDto model)
        {
            if (model.KisiBolumID == 1) // Sayısal ise 
            {
                var tythedef = new TytHedef();
                tythedef.OlusturulmaTarihi = DateTime.Now;
                tythedef.OlusturanKisiID = model.KisiID;
                _tytHedefService.TAdd(tythedef);
                //-------------------------------&&//
                var aytmodel = new AytSayHedef();
                aytmodel.OlusturanKisiID = model.KisiID;
                aytmodel.OlusturulmaTarihi = DateTime.Now;
                _aytSayService.TAdd(aytmodel);

                var sontytid = _tytHedefService.GetLatest().TabloID;
                var aytsonid = _aytSayService.GetLatest().TabloID;

                var hedef = new HedefGenelTanimlari();
                hedef.OlusturulmaTarihi = DateTime.Now;
                hedef.OlusturanKisiID = model.KisiID;
                hedef.HedefYapanKisiID = model.KisiID;
                hedef.HedefTytID = sontytid;
                hedef.HedefAytID = aytsonid;
                hedef.HedefSiralama = 0;
                hedef.HedefPuani = 0;
                hedef.HedefNotu = "Haydi hedefini belirle ve ilerleyişini görelim..";

                _genelTanimlariService.TAdd(hedef);
                return Ok();
            }
            else if (model.KisiBolumID == 2)//Ea
            {
                var tythedef = new TytHedef();
                tythedef.OlusturulmaTarihi = DateTime.Now;
                tythedef.OlusturanKisiID = model.KisiID;
                _tytHedefService.TAdd(tythedef);
                //-------------------------------&&//
                var aytmodel = new AytEaHedef();
                aytmodel.OlusturanKisiID = model.KisiID;
                aytmodel.OlusturulmaTarihi = DateTime.Now;
                _aytEaService.TAdd(aytmodel);

                var sontytid = _tytHedefService.GetLatest().TabloID;
                var aytsonid = _aytEaService.GetLatest().TabloID;

                var hedef = new HedefGenelTanimlari();
                hedef.OlusturulmaTarihi = DateTime.Now;
                hedef.OlusturanKisiID = model.KisiID;
                hedef.HedefYapanKisiID = model.KisiID;
                hedef.HedefTytID = sontytid;
                hedef.HedefAytID = aytsonid;
                hedef.HedefSiralama = 0;
                hedef.HedefPuani = 0;
                hedef.HedefNotu = "Haydi hedefini belirle ve ilerleyişini görelim..";

                _genelTanimlariService.TAdd(hedef);
                return Ok();
            }
            else if (model.KisiBolumID == 3)//Sozel
            {
                var tythedef = new TytHedef();
                tythedef.OlusturulmaTarihi = DateTime.Now;
                tythedef.OlusturanKisiID = model.KisiID;
                _tytHedefService.TAdd(tythedef);
                //-------------------------------&&//
                var aytmodel = new AytSozelHedef();
                aytmodel.OlusturanKisiID = model.KisiID;
                aytmodel.OlusturulmaTarihi = DateTime.Now;
                _aytSozelService.TAdd(aytmodel);

                var sontytid = _tytHedefService.GetLatest().TabloID;
                var aytsonid = _aytSozelService.GetLatest().TabloID;

                var hedef = new HedefGenelTanimlari();
                hedef.OlusturulmaTarihi = DateTime.Now;
                hedef.OlusturanKisiID = model.KisiID;
                hedef.HedefYapanKisiID = model.KisiID;
                hedef.HedefTytID = sontytid;
                hedef.HedefAytID = aytsonid;
                hedef.HedefSiralama = 0;
                hedef.HedefPuani = 0;
                hedef.HedefNotu = "Haydi hedefini belirle ve ilerleyişini görelim..";

                _genelTanimlariService.TAdd(hedef);
                return Ok();
            }
            else if (model.KisiBolumID == 4)//Yd
            {
                var tythedef = new TytHedef();
                tythedef.OlusturulmaTarihi = DateTime.Now;
                tythedef.OlusturanKisiID = model.KisiID;
                _tytHedefService.TAdd(tythedef);
                //-------------------------------&&//
                var aytmodel = new AytYdHedef();
                aytmodel.OlusturanKisiID = model.KisiID;
                aytmodel.OlusturulmaTarihi = DateTime.Now;
                _aytYdHedefService.TAdd(aytmodel);

                var sontytid = _tytHedefService.GetLatest().TabloID;
                var aytsonid = _aytYdHedefService.GetLatest().TabloID;

                var hedef = new HedefGenelTanimlari();
                hedef.OlusturulmaTarihi = DateTime.Now;
                hedef.OlusturanKisiID = model.KisiID;
                hedef.HedefYapanKisiID = model.KisiID;
                hedef.HedefTytID = sontytid;
                hedef.HedefAytID = aytsonid;
                hedef.HedefSiralama = 0;
                hedef.HedefPuani = 0;
                hedef.HedefNotu = "Haydi hedefini belirle ve ilerleyişini görelim..";

                _genelTanimlariService.TAdd(hedef);
                return Ok();
            }
            else
            {
                return BadRequest("Lütfen Hangi Bölüm Öğrencisi Olduğunuzu Belirtiniz.");
            }
        }
        #endregion
        #region Tyt
        [HttpGet]
        public IActionResult KisiTytHedefiGetir(int id)
        {
            var kisitytid = _genelTanimlariService.GetHedefWithUserID(id).HedefTytID;
            var result = _tytHedefService.TGetByid(kisitytid);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult TytHedefGetWithTabloID(int id)
        {
            var result = _tytHedefService.TGetByid(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult TytHedefGuncelle(TytHedefDto model)
        {
            var result = _tytHedefService.TGetByid(model.TabloID);
            result.TytMatDogruHedefi = model.TytMatDogruHedefi;
            result.TytMatYanlisHedefi = model.TytMatYanlisHedefi;
            result.TytFenDogruHedefi = model.TytFenDogruHedefi;
            result.TytFenYanlisHedefi = model.TytFenYanlisHedefi;
            result.TytTurkceDogruHedefi = model.TytTurkceDogruHedefi;
            result.TytTurkceYanlisHedefi = model.TytTurkceYanlisHedefi;
            result.TytSosyalDogruHedefi = model.TytSosyalDogruHedefi;
            result.TytSosyalYanlisHedefi = model.TytSosyalYanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;

            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;

            _tytHedefService.TUpdate(result);

            return Ok();
        }
        [HttpPost]
        public IActionResult KisiAytHedefiGetir(KisiAytHedefDto model)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(model.KisiID).HedefAytID;
            if (model.KisiBolumID == 0)
            {
                return BadRequest("Lütfen Hangi Bölüm Öğrencisi Olduğunuzu Belirtiniz.");
            }
            if (model.KisiBolumID == 1) // Sayısal ise 
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
        #endregion
        #region AytSay
        [HttpGet]
        public IActionResult AytSayHedefGetWithID(int id)
        {
            var value =_aytSayService.TGetByid(id);
            return Ok(value);
        }
        [HttpGet]
        public IActionResult KisiAytSayHedefiGetir(int id)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(id).HedefAytID;
            var result = _aytSayService.TGetByid(kisiaytid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AytSayHedefUpdate(AytSayHedefUpdateDto model)
        {
            var result = _aytSayService.TGetByid(model.TabloID);
            result.AytMatDogruHedefi = model.AytMatDogruHedefi;
            result.AytMatYanlisHedefi = model.AytMatYanlisHedefi;
            result.AytFizikDogruHedefi = model.AytFizikDogruHedefi;
            result.AytFizikYanlisHedefi = model.AytFizikYanlisHedefi;
            result.AytKimyaDogruHedefi = model.AytKimyaDogruHedefi;
            result.AytKimyaYanlisHedefi = model.AytKimyaYanlisHedefi;
            result.AytBiyolojiDogruHedefi = model.AytBiyolojiDogruHedefi;
            result.AytBiyolojiYanlisHedefi = model.AytBiyolojiYanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytSayService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AytSayHedefUpdateWithKisiID(AytSayHedefUpdateDto model)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(model.GuncelleyenKisiID).HedefAytID;
            var result = _aytSayService.TGetByid(kisiaytid);
            result.AytMatDogruHedefi = model.AytMatDogruHedefi;
            result.AytMatYanlisHedefi = model.AytMatYanlisHedefi;
            result.AytFizikDogruHedefi = model.AytFizikDogruHedefi;
            result.AytFizikYanlisHedefi = model.AytFizikYanlisHedefi;
            result.AytKimyaDogruHedefi = model.AytKimyaDogruHedefi;
            result.AytKimyaYanlisHedefi = model.AytKimyaYanlisHedefi;
            result.AytBiyolojiDogruHedefi = model.AytBiyolojiDogruHedefi;
            result.AytBiyolojiYanlisHedefi = model.AytBiyolojiYanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytSayService.TUpdate(result);
            return Ok();
        }
        #endregion
        #region AytEa
        [HttpGet]
        public IActionResult AytEaHedefGetWithID(int id)
        {
            var value = _aytEaService.TGetByid(id);
            return Ok(value);
        }
        [HttpGet]
        public IActionResult KisiAytEaHedefiGetir(int id)
        {
            var kisitytid = _genelTanimlariService.GetHedefWithUserID(id).HedefAytID;
            var result = _aytEaService.TGetByid(kisitytid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AytEaHedefUpdate(AytEaHedefUpdateDto model)
        {
            var result = _aytEaService.TGetByid(model.TabloID);
            result.AytMatDogruHedefi = model.AytMatDogruHedefi;
            result.AytMatYanlisHedefi = model.AytMatYanlisHedefi;
            result.AytEdebiyatDogruHedefi = model.AytEdebiyatDogruHedefi;
            result.AytEdebiyatYanlisHedefi = model.AytEdebiyatYanlisHedefi;
            result.AytTarih1DogruHedefi = model.AytTarih1DogruHedefi;
            result.AytTarih1YanlisHedefi = model.AytTarih1YanlisHedefi;
            result.AytCografya1DogruHedefi = model.AytCografya1DogruHedefi;
            result.AytCografya1YanlisHedefi = model.AytCografya1YanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytEaService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AytEaHedefUpdateWithKisiID(AytEaHedefUpdateDto model)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(model.GuncelleyenKisiID).HedefAytID;
            var result = _aytEaService.TGetByid(kisiaytid);
            result.AytMatDogruHedefi = model.AytMatDogruHedefi;
            result.AytMatYanlisHedefi = model.AytMatYanlisHedefi;
            result.AytEdebiyatDogruHedefi = model.AytEdebiyatDogruHedefi;
            result.AytEdebiyatYanlisHedefi = model.AytEdebiyatYanlisHedefi;
            result.AytTarih1DogruHedefi = model.AytTarih1DogruHedefi;
            result.AytTarih1YanlisHedefi = model.AytTarih1YanlisHedefi;
            result.AytCografya1DogruHedefi = model.AytCografya1DogruHedefi;
            result.AytCografya1YanlisHedefi = model.AytCografya1YanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytEaService.TUpdate(result);
            return Ok();
        }
        #endregion
        #region AytSozel
        [HttpGet]
        public IActionResult AytSozelHedefGetWithID(int id)
        {
            var value = _aytSozelService.TGetByid(id);
            return Ok(value);
        }
        [HttpGet]
        public IActionResult KisiAytSozelHedefiGetir(int id)
        {
            var kisitytid = _genelTanimlariService.GetHedefWithUserID(id).HedefAytID;
            var result = _aytSozelService.TGetByid(kisitytid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AytSozelHedefUpdate(AytSozelHedefUpdateDto model)
        {
            var result = _aytSozelService.TGetByid(model.TabloID);
            result.AytMatDogruHedefi = model.AytMatDogruHedefi;
            result.AytMatYanlisHedefi = model.AytMatYanlisHedefi;
            result.AytEdebiyatDogruHedefi = model.AytEdebiyatDogruHedefi;
            result.AytEdebiyatYanlisHedefi = model.AytEdebiyatYanlisHedefi;
            result.AytTarih1DogruHedefi = model.AytTarih1DogruHedefi;
            result.AytTarih1YanlisHedefi = model.AytTarih1YanlisHedefi;
            result.AytCografya1DogruHedefi = model.AytCografya1DogruHedefi;
            result.AytCografya1YanlisHedefi = model.AytCografya1YanlisHedefi;
            result.AytTarih2DogruHedefi = model.AytTarih2DogruHedefi;
            result.AytTarih2YanlisHedefi = model.AytTarih2YanlisHedefi;
            result.AytCografya2DogruHedefi = model.AytCografya2DogruHedefi;
            result.AytCografya2YanlisHedefi = model.AytCografya2YanlisHedefi;
            result.AytDinDogruHedefi = model.AytDinDogruHedefi;
            result.AytDinYanlisHedefi = model.AytDinYanlisHedefi;
            result.AytFelsefeDogruHedefi = model.AytFelsefeDogruHedefi;
            result.AytFelsefeYanlisHedefi = model.AytFelsefeYanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytSozelService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AytSozelHedefUpdateWithKisiID(AytSozelHedefUpdateDto model)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(model.GuncelleyenKisiID).HedefAytID;
            var result = _aytSozelService.TGetByid(kisiaytid);
            result.AytMatDogruHedefi = model.AytMatDogruHedefi;
            result.AytMatYanlisHedefi = model.AytMatYanlisHedefi;
            result.AytEdebiyatDogruHedefi = model.AytEdebiyatDogruHedefi;
            result.AytEdebiyatYanlisHedefi = model.AytEdebiyatYanlisHedefi;
            result.AytTarih1DogruHedefi = model.AytTarih1DogruHedefi;
            result.AytTarih1YanlisHedefi = model.AytTarih1YanlisHedefi;
            result.AytCografya1DogruHedefi = model.AytCografya1DogruHedefi;
            result.AytCografya1YanlisHedefi = model.AytCografya1YanlisHedefi;
            result.AytTarih2DogruHedefi = model.AytTarih2DogruHedefi;
            result.AytTarih2YanlisHedefi = model.AytTarih2YanlisHedefi;
            result.AytCografya2DogruHedefi = model.AytCografya2DogruHedefi;
            result.AytCografya2YanlisHedefi = model.AytCografya2YanlisHedefi;
            result.AytDinDogruHedefi = model.AytDinDogruHedefi;
            result.AytDinYanlisHedefi = model.AytDinYanlisHedefi;
            result.AytFelsefeDogruHedefi = model.AytFelsefeDogruHedefi;
            result.AytFelsefeYanlisHedefi = model.AytFelsefeYanlisHedefi;
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytSozelService.TUpdate(result);
            return Ok();
        }
        #endregion
        #region AytYabanciDil
        [HttpGet]
        public IActionResult AytYdHedefGetWithID(int id)
        {
            var value = _aytYdHedefService.TGetByid(id);
            return Ok(value);
        }
        [HttpGet]
        public IActionResult KisiAytYdHedefiGetir(int id)
        {
            var kisitytid = _genelTanimlariService.GetHedefWithUserID(id).HedefAytID;
            var result = _aytYdHedefService.TGetByid(kisitytid);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AytYdHedefUpdate(AytYdHedefUpdateDto model)
        {
            var result = _aytYdHedefService.TGetByid(model.TabloID);
            result.AytYdDogruHedefi = model.AytYdDogruHedefi;
            result.AytYdYanlisHedefi = model.AytYdYanlisHedefi;
 
            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytYdHedefService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AytYdHedefUpdateWithKisiID(AytYdHedefUpdateDto model)
        {
            var kisiaytid = _genelTanimlariService.GetHedefWithUserID(model.GuncelleyenKisiID).HedefAytID;
            var result = _aytYdHedefService.TGetByid(kisiaytid);
            result.AytYdDogruHedefi = model.AytYdDogruHedefi;
            result.AytYdYanlisHedefi = model.AytYdYanlisHedefi;

            result.HedefToplamNet = model.HedefToplamNet;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _aytYdHedefService.TUpdate(result);
            return Ok();
        }
        #endregion
    }
}
