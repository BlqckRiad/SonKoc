using KurumService.BusinessLayer.Abstract;
using KurumService.DtoLayer.Dtos;
using KurumService.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KurumService.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KurumController : ControllerBase
    {
        private readonly IKurumService _kurumService;
        private readonly IKisiService _kisiService;
        public KurumController(IKurumService kurumService, IKisiService kisiService)
        {
            _kisiService = kisiService;
            _kurumService = kurumService;
        }
        [HttpGet]
        public IActionResult GetKurumIndexData(int kurumid)
        {
            var kurum =_kurumService.TGetByid(kurumid);
            var kurummaxuser =kurum.KurumMaxOgrenciLimiti;
            var kurumuser = kurum.KurumOgrenciSayisi;
            var index = new KurumIndexDto();
            index.KurumMaxUserCount = kurummaxuser; ;
            index.KurumUserCount = kurumuser;

            return Ok(index);
        }

        [HttpGet]
        public IActionResult GetAllKurums()
        {
            var result = _kurumService.TGetList().Where(x => x.SilindiMi == false);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult GetUsersForKurum(KurumAndKisiDto model)
        {
            var result = _kisiService.TGetList().Where(x => x.KisiIlgiliKurumID == model.KurumID).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddKurum(Kurum model)
        {
            var password = model.KurumPassword;
            model.OlusturulmaTarihi = DateTime.Now;

            using (SHA256 sha = SHA256.Create())
            {
                string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                model.KurumPassword = SifrelenmisVeri;
            }
            model.OlusturulmaTarihi = DateTime.Now;

            _kurumService.TAdd(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult UpadateKurum(KurumUpdateDto model)
        {
            var result = _kurumService.TGetByid(model.TabloID);
            result.KurumAdi = model.KurumAdi;
            result.KurumSahibiAdi = model.KurumSahibiAdi;
            result.KurumAdresi = model.KurumAdresi;
            result.KurumImageUrl = model.KurumImageUrl;
            result.KurumImageID = model.KurumImageID;
            result.KurumOgrenciSayisi = model.KurumOgrenciSayisi;
            result.KurumMaxOgrenciLimiti = model.KurumMaxOgrenciLimiti;
            result.KurumTelNo = model.KurumTelNo;
            result.KurumSahibiTelNo = model.KurumSahibiTelNo;
            result.KurumSahibiEmail = model.KurumSahibiEmail;
            result.KurumWebSiteUrl = model.KurumWebSiteUrl;
            result.KurumInstaKullaniciAdi = model.KurumInstaKullaniciAdi;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            result.KurumTipiID = model.KurumTipiID;

            result.GuncellenmeTarihi = DateTime.Now;
            _kurumService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult KurumEmailUpdate(KurumEmailPasswordDto model)
        {
            var result = _kurumService.TGetByid(model.KurumID);
            result.KurumEmail = model.NewEmailOrPass;
            _kurumService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult KurumPasswordUpdate(KurumEmailPasswordDto model)
        {
            var password = model.NewEmailOrPass;
            var result = _kurumService.TGetByid(model.KurumID);
            using (SHA256 sha = SHA256.Create())
            {
                string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                result.KurumPassword = SifrelenmisVeri;
            }
            _kurumService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult KurumPasswordChange(KurumPasswordChangeDto model)
        {
            var result = _kurumService.TGetByid(model.KurumID);
            if (result != null)
            {
                var password = model.OldPassword;
                using (SHA256 sha = SHA256.Create())
                {
                    string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                    if (result.KurumPassword == SifrelenmisVeri)
                    {
                        var newpassword = model.NewPassword;
                        string newpasswordhashed = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(newpassword)));
                        result.KurumPassword = newpasswordhashed;
                        _kurumService.TUpdate(result);
                        return Ok();
                    }
                    return BadRequest("Girdiğiniz Şifre Hatalı");
                }
            }
            return NotFound("Kurum Bulunamadı");
        }
        [HttpGet("{name}")]
        public IActionResult GetKurumWithName (string name)
        {
            var result = _kurumService.TGetList().Where(x=> x.KurumAdi == name);
            return Ok(result);
        }
       
    }
}
