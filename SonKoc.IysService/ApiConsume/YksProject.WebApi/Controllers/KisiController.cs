using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using YksProject.BusinessLayer.Abstract;
using YksProject.EntityLayer.Concrete;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using YksProject.DtoLayer.Dtos;
using System.Linq;

namespace YksProject.YksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class KisiController : ControllerBase
    {
        private readonly IKisiService _kisiService;
        public KisiController(IKisiService kisiService)
        {
            _kisiService = kisiService;
        }
        [HttpGet]
        public IActionResult ListKisi()
        {
            var result = _kisiService.TGetList();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteKisi(int id)
        {
            var values = _kisiService.TGetByid(id);
            _kisiService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateKisi(Kisi model )
        {
            
            _kisiService.TUpdate(model);
            return Ok();
        }


         [HttpPost]
         public IActionResult AddKisi(Kisi model)
         {
            var password = model.KisiPassword;
            model.OlusturulmaTarihi = DateTime.Now;
            
             using (SHA256 sha = SHA256.Create())
             {
                   string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                   model.KisiPassword = SifrelenmisVeri;
             }
            model.OlusturulmaTarihi = DateTime.Now;
            model.OlusturanKisiID = 1;
            model.RolID = 2;
               _kisiService.TAdd(model);
               return Ok();
         }

    [HttpGet("{id}")]
        public IActionResult GetKisi(int id)
        {
            var result = _kisiService.TGetByid(id);
            return Ok(result);
        }
        [HttpGet("email/{email}")]
        public Kisi GetKisiWithEmail(string email)
        {
            var result = _kisiService.GetKisiWithEmail(email);
            return result;
        }

        [HttpGet("username/{username}")]
        public Kisi GetKisiWithUsername(string username)
        {
            var result = _kisiService.GetKisiWithUsername(username);
            return result;
        }
        [HttpGet("photoid/{id}")]
        public string GetPhotoUrlWithID(int id)
        {
            var result = _kisiService.GetPhotoUrlWithID(id);
            return result;
        }

        [HttpGet("{ogrlistforadmin}")]
        public ActionResult<List<AdminOgrList>> ListBolum()
        {
            var kisiler = _kisiService.TGetList()
                                      .Where(x => x.SilindiMi == false && x.RolID == 2)
                                      .ToList();

            var adminOgrList = kisiler.Select(kisi => new AdminOgrList
            {
                TabloID = kisi.TabloID,
                KisiAdi = kisi.KisiAdi,
                KisiSoyAdi = kisi.KisiSoyAdi,
                KisiKullaniciAdi = kisi.KisiKullaniciAdi,
                KisiEmail = kisi.KisiEmail,
                KisiTelNo = kisi.KisiTelNo,
                OlusturulmaTarihi = kisi.OlusturulmaTarihi
            }).ToList();

            return adminOgrList;
        }

        [HttpGet("kisigetwithshortusername/{shortusername}")]
        public ActionResult<List<KisiMessageDto>> GetKisiWithShortUserName(string shortusername)
        {
            var result = _kisiService.GetKisiWithShortUserName(shortusername);

            // Eğer GetKisiWithShortUserName metodu bir koleksiyon döndürüyor olmalıysa, bu kısmı güncelleyin.
            var kisimessage = result.Select(kisi => new KisiMessageDto
            {
                TabloID = kisi.TabloID,
                KisiKullaniciAdi = kisi.KisiKullaniciAdi,
                KisiImageUrl = kisi.KisiImageUrl
            }).ToList();

            return kisimessage;
        }


    }
}
