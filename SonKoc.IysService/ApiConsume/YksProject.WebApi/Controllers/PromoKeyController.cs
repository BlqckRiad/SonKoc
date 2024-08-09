using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.DtoLayer.Dtos.PromoKey;
using YksProject.EntityLayer.Concrete;

namespace YksProject.WebApi.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PromoKeyController : ControllerBase
    {
        private readonly IPromoKeyService _promokeyservice;
        public PromoKeyController(IPromoKeyService service)
        {
            _promokeyservice = service;
        }
        [HttpPost]
        public IActionResult PromoKeyAdd (PromoKeyAddDto model)
        {
            var key = new PromoKey();
            key.PromoKod = model.PromoKod;
            key.PromoKodNeİcin = model.PromoKodNeİcin;
            key.OlusturanKisiID=model.OlusturanKisiID;
            key.OlusturulmaTarihi = DateTime.Now;
            key.PromoKeyLimit = model.PromoKeyLimit;
            key.PromoKeyKullanimSayisi = model.PromoKeyKullanimSayisi;
            key.PromoKeyYuzdeKacIndirim = model.PromoKeyYuzdeKacIndirim;

            _promokeyservice.TAdd(key);
            return Ok();
        }
        [HttpPost]
        public IActionResult PromoKeyUsed(string keys)
        {
            var key = _promokeyservice.KeyGetWitKod(keys);
            key.PromoKeyKullanimSayisi = +1;
            _promokeyservice.TUpdate(key);
            return Ok(key);
        }
        [HttpGet]
       public IActionResult GetPromoKeyWithKey(string key)
        {
            var promokey = _promokeyservice.KeyGetWitKod(key);
            if(promokey == null)
            {
                return NotFound(key);
            }
            return Ok(promokey);
        }
        [HttpPost]
        public IActionResult DeletePromoKey(DeleteDto model)
        {
            var promokey = _promokeyservice.TGetByid(model.TabloID);
            promokey.SilenKisiID = model.SilenKisiID;
            promokey.SilindiMi = true;
            _promokeyservice.TUpdate(promokey);
            return Ok();
        }
        [HttpPost]
        public IActionResult PromoKeyUpdate(PromoKeyUpdateDto model)
        {
            var promokey = _promokeyservice.TGetByid(model.TabloID);
            promokey.PromoKeyLimit = model.PromoKeyLimit;
            promokey.PromoKod = model.PromoKod;
            promokey.PromoKodNeİcin = model.PromoKodNeİcin;
            promokey.PromoKeyKullanimSayisi = model.PromoKeyKullanimSayisi;
            promokey.PromoKeyYuzdeKacIndirim = model.PromoKeyYuzdeKacIndirim;
            promokey.GuncelleyenKisiID = model.GuncelleyenKisiID;
            promokey.GuncellenmeTarihi = DateTime.Now;
            _promokeyservice.TUpdate(promokey);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllPromoKeys()
        {
            var keys = _promokeyservice.TGetList().Where(x=> x.SilindiMi==false);
            return Ok(keys);
        }
    }
}
