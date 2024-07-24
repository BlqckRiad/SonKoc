using KurumService.BusinessLayer.Abstract;
using KurumService.DtoLayer.Dtos;
using KurumService.EntityLayer.Concrete;
using KurumService.WebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;

namespace KurumService.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KurumOgrenciController : ControllerBase
    {
        private readonly IKisiService _kisiService;
        private readonly ITokenCreateService _token;
        public KurumOgrenciController(IKisiService kisiService , ITokenCreateService token)
        {
            _kisiService = kisiService; 
            _token = token;
        }
        [HttpPost]
        public IActionResult OgrenciEkle(KurumKisiAddDto model)
        {
            var user = new Kisi();

            var password = model.KisiPassword;
            using (SHA256 sha = SHA256.Create())
            {
                string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                user.KisiPassword = SifrelenmisVeri;
            }

            user.KisiAdi = model.KisiAdi;
            user.KisiSoyAdi = model.KisiSoyAdi;
            user.KisiKullaniciAdi = model.KisiKullaniciAdi;
            user.KisiEmail = model.KisiEmail;
            user.KisiDogumTarihi = model.KisiDogumTarihi;
            user.KisiKurumSahibiMi = model.KisiKurumSahibiMi;
            user.KisiIlgiliKurumID = model.KisiIlgiliKurumID;
            user.KisiCinsiyetID = model.KisiCinsiyetID;
            user.RolID = 2;
            user.OlusturulmaTarihi = DateTime.Now;
            user.OlusturanKisiID = model.KisiIlgiliKurumID;
            user.KisiKurumSahibiMi = true;
            DateTime kisiDogumTarihi = model.KisiDogumTarihi; // Doğum tarihi
            int kisiYasi = _token.GetAge(kisiDogumTarihi);

            user.KisiYasi = kisiYasi;
            _kisiService.TAdd(user);
            return Ok();
        }
       
    }
}
