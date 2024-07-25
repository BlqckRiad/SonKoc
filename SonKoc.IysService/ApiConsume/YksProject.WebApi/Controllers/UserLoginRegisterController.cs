using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.Text;
using System;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using System.Security.Cryptography;
using YksProject.WebApi.Service;
using YksProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserLoginRegisterController : ControllerBase
{
    private readonly IKisiService _kisiService;
    private readonly ITokenCreateService _tokenCreateService;
    private readonly IRollerService _rollerService;

    public UserLoginRegisterController(IKisiService kisiService, ITokenCreateService tokenCreateService, IRollerService rollerService)
    {
        _kisiService = kisiService;
        _tokenCreateService = tokenCreateService;
        _rollerService = rollerService;
    }

    [HttpPost("loginWithUserName")]
    public IActionResult LoginWithUserName(LoginDto model)
    {
        var userName = model.UserNameOrEmail;
        var result = _kisiService.GetKisiWithUsername(userName);
        if (result.SilindiMi == true)
        {
            return BadRequest("Kurum üyeliği son bulmuştur.");
        }

        if (result != null)
        {
            var kisiRolID = result.RolID;
            var kisiImageUrl = result.KisiImageUrl;
            using (SHA256 sha = SHA256.Create())
            {
                // Kullanıcının girdiği şifreyi hash'leyin
                string hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

                // Veritabanındaki hash ile kullanıcının girdiği şifre hash'ini karşılaştırın
                if (hashedPassword == result.KisiPassword)
                {
                    var userstat = result;
                    userstat.UserOnlineMi = true;
                    _kisiService.TUpdate(userstat);
                    var rolAdi = _rollerService.TGetByid(kisiRolID).RolAdi;
                    var token = _tokenCreateService.CreateTokenWithGenericStructer(rolAdi);

                    var tokenValidate = new TokenValidateDto
                    {
                        TabloID = result.TabloID,
                        UserName = result.KisiKullaniciAdi,
                        Token = token,
                        Role = rolAdi,
                      KisiImageUrl = kisiImageUrl
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
        var result = _kisiService.GetKisiWithEmail(email);
        if (result.SilindiMi == true)
        {
            return BadRequest("Kurum üyeliği son bulmuştur.");
        }
        var kisiImageUrl = result.KisiImageUrl;
        if (result != null)
        {
            var kisiRolID = result.RolID;
            using (SHA256 sha = SHA256.Create())
            {
                // Kullanıcının girdiği şifreyi hash'leyin
                string hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

                // Veritabanındaki hash ile kullanıcının girdiği şifre hash'ini karşılaştırın
                if (hashedPassword == result.KisiPassword)
                {
                    var rolAdi = _rollerService.TGetByid(kisiRolID).RolAdi;
                    var token = _tokenCreateService.CreateTokenWithGenericStructer(rolAdi);
                    var tokenValidate = new TokenValidateDto
                    {
                        TabloID = result.TabloID,
                        UserName = result.KisiKullaniciAdi,
                        Token = token,
                        Role = rolAdi,
                        KisiImageUrl = kisiImageUrl
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

    [HttpPost("logout")]
    public IActionResult logout([FromBody] LogoutRequest request)
    {
        var result = _kisiService.TGetByid(request.Id);
        result.UserOnlineMi = false;
        _kisiService.TUpdate(result);
        return Ok();
    }

}
