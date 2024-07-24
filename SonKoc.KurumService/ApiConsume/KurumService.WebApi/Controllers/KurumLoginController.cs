using KurumService.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using KurumService.DtoLayer.Dtos;
using System.Security.Cryptography;
using KurumService.WebApi.Service;
using System.Linq;

namespace KurumService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurumLoginController : ControllerBase
    {
        private readonly IKurumService _kurumService;
        private readonly ITokenCreateService _tokenCreateService;
        public KurumLoginController(IKurumService kurumService, ITokenCreateService tokenCreateService)
        {
            _kurumService = kurumService;   
            _tokenCreateService = tokenCreateService;
        }


        [HttpPost("loginWithUserName")]
        public IActionResult LoginWithUserName(LoginDto model)
        {
            var userName = model.UserNameOrEmail;
            var result = _kurumService.GetKurumWithUsername(userName);


            if (result != null)
            {
                var ImageUrl = result.KurumImageUrl;
                using (SHA256 sha = SHA256.Create())
                {
                    // Kullanıcının girdiği şifreyi hash'leyin
                    string hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

                    // Veritabanındaki hash ile kullanıcının girdiği şifre hash'ini karşılaştırın
                    if (hashedPassword == result.KurumPassword)
                    {
                       
                        var rolAdi = "Kurum";
                        var token = _tokenCreateService.CreateTokenWithGenericStructer(rolAdi);

                        var tokenValidate = new TokenValidateDto
                        {
                            TabloID = result.TabloID,
                            UserName = result.KurumAdi,
                            Token = token,
                            Role = rolAdi,
                            KisiImageUrl = result.KurumImageUrl
                        };
                        return Ok(tokenValidate);

                    }
                    else
                    {
                        // Şifreler eşleşmiyorsa, hata dönülebilir veya hata mesajı verilebilir
                        return BadRequest("Hatalı şifre.");
                    }
                }
            }
            else
            {
                // Kullanıcı bulunamadı, uygun bir yanıt döndürün.
                return NotFound("Kullanıcı bulunamadı.");
            }
        }

        [HttpPost("loginWithEmail")]
        public IActionResult LoginWithEmail(LoginDto model)
        {
            var email = model.UserNameOrEmail;
            var result = _kurumService.GetKurumWithEmail(email);
            var kisiImageUrl = result.KurumImageUrl;
            if (result != null)
            {
               
                using (SHA256 sha = SHA256.Create())
                {
                    // Kullanıcının girdiği şifreyi hash'leyin
                    string hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

                    // Veritabanındaki hash ile kullanıcının girdiği şifre hash'ini karşılaştırın
                    if (hashedPassword == result.KurumPassword)
                    {

                        var rolAdi = "Kurum";
                        var token = _tokenCreateService.CreateTokenWithGenericStructer(rolAdi);

                        var tokenValidate = new TokenValidateDto
                        {
                            TabloID = result.TabloID,
                            UserName = result.KurumAdi,
                            Token = token,
                            Role = rolAdi,
                            KisiImageUrl = result.KurumImageUrl
                        };
                        return Ok(tokenValidate);

                    }
                    else
                    {
                        // Şifreler eşleşmiyorsa, hata dönülebilir veya hata mesajı verilebilir
                        return BadRequest("Hatalı şifre.");
                    }
                }
            }
            else
            {
                // Kullanıcı bulunamadı, uygun bir yanıt döndürün.
                return NotFound("Kullanıcı bulunamadı.");
            }
        }
        [HttpPost("LoginYapanKurumMu")]
        public IActionResult LoginYapanKurumMu(UserNameOrEmailDto model)
        {
            var result = _kurumService.GetKurumWithEmailOrUserName(model.usernameoremail);
            if (result == null)
            {
                return BadRequest("Kisi Kurum Değildir");
            }
            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult logout([FromBody] LogoutRequest request)
        {
            var result = _kurumService.TGetByid(request.Id);
            result.KurumOnlineMi = false;
            _kurumService.TUpdate(result);
            return Ok();
        }
    }
}
