using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using YksProject.Web_UI.Models.Dtos;




namespace YksProject.Web_UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AccountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region ViewModel
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        #endregion
        #region ApiModel
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            
            var client2 = _clientFactory.CreateClient();
            var apiUrl2 = "https://localhost:44346/api/KurumLogin/LoginYapanKurumMu";
            var datalogin = new UserNameOrEmailDto();
            datalogin.usernameoremail = model.UserNameOrEmail;
            var jsonContent2 = JsonConvert.SerializeObject(datalogin);
            var httpContent2 = new StringContent(jsonContent2, Encoding.UTF8, "application/json");
            var response2 = await client2.PostAsync(apiUrl2, httpContent2);
            if (response2.IsSuccessStatusCode)
            {
                var input = model.UserNameOrEmail;
                var client = _clientFactory.CreateClient();
                var apiURL = IsEmail(input) ? "https://localhost:44346/api/KurumLogin/loginWithEmail" : "https://localhost:44346/api/KurumLogin/loginWithUserName";

                var jsonContent = JsonConvert.SerializeObject(model);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiURL, httpContent);

                if (response.IsSuccessStatusCode)
                {

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<TokenValidateDto>(responseContent);
                    if (responseObject.KisiImageUrl == null)
                    {
                        responseObject.KisiImageUrl = "http://localhost:6079/images/logo.jpg";
                    }
                    if (responseObject.KisiImageUrl == "")
                    {
                        responseObject.KisiImageUrl = "http://localhost:6079/images/logo.jpg";
                    }
                    try
                    {
                        // Mevcut oturumu sonlandır
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        var claims = new List<Claim>();

                        if (!string.IsNullOrEmpty(responseObject.UserName))
                            claims.Add(new Claim(ClaimTypes.Name, responseObject.UserName));


                        claims.Add(new Claim("TabloID", responseObject.TabloID.ToString()));

                        if (!string.IsNullOrEmpty(responseObject.Token))
                            claims.Add(new Claim("Token", responseObject.Token));

                        if (!string.IsNullOrEmpty(responseObject.KisiImageUrl))
                            claims.Add(new Claim("KisiImageUrl", responseObject.KisiImageUrl));

                        if (!string.IsNullOrEmpty(responseObject.Role))
                            claims.Add(new Claim(ClaimTypes.Role, responseObject.Role));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3),
                            IsPersistent = true,
                            IssuedUtc = DateTimeOffset.UtcNow,
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                        return Json(new
                        {
                            success = true,
                            data = new
                            {
                                responseObject.TabloID,
                                responseObject.UserName,
                                responseObject.Token,
                                responseObject.Role,
                                responseObject.KisiImageUrl
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda mevcut oturumu sonlandır
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        return StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            success = false,
                            message = "Oturum açma işlemi sırasında bir hata oluştu.",
                            error = ex.Message
                        });
                    }
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { success = false, message = responseContent });
                }



            }
            else
            {
                var input = model.UserNameOrEmail;
                var client = _clientFactory.CreateClient();
                var apiURL = IsEmail(input) ? "http://localhost:3798/api/UserLoginRegister/loginWithEmail" : "http://localhost:3798/api/UserLoginRegister/loginWithUserName";

                var jsonContent = JsonConvert.SerializeObject(model);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiURL, httpContent);

                if (response.IsSuccessStatusCode)
                {

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<TokenValidateDto>(responseContent);
                    if (responseObject.KisiImageUrl == null)
                    {
                        responseObject.KisiImageUrl = "http://localhost:6079/images/logo.jpg";
                    }
                    if (responseObject.KisiImageUrl == "")
                    {
                        responseObject.KisiImageUrl = "http://localhost:6079/images/logo.jpg";
                    }
                    try
                    {
                        // Mevcut oturumu sonlandır
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        var claims = new List<Claim>();

                        if (!string.IsNullOrEmpty(responseObject.UserName))
                            claims.Add(new Claim(ClaimTypes.Name, responseObject.UserName));


                        claims.Add(new Claim("TabloID", responseObject.TabloID.ToString()));

                        if (!string.IsNullOrEmpty(responseObject.Token))
                            claims.Add(new Claim("Token", responseObject.Token));

                        if (!string.IsNullOrEmpty(responseObject.KisiImageUrl))
                            claims.Add(new Claim("KisiImageUrl", responseObject.KisiImageUrl));

                        if (!string.IsNullOrEmpty(responseObject.Role))
                            claims.Add(new Claim(ClaimTypes.Role, responseObject.Role));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3),
                            IsPersistent = true,
                            IssuedUtc = DateTimeOffset.UtcNow,
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                        return Json(new
                        {
                            success = true,
                            data = new
                            {
                                responseObject.TabloID,
                                responseObject.UserName,
                                responseObject.Token,
                                responseObject.Role,
                                responseObject.KisiImageUrl
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda mevcut oturumu sonlandır
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        return StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            success = false,
                            message = "Oturum açma işlemi sırasında bir hata oluştu.",
                            error = ex.Message
                        });
                    }
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { success = false, message = responseContent });
                }
            }
        }





        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {

            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/Kisi";

            // BolumAddViewModel nesnesini JSON'a dönüştürün
            var jsonContent = JsonConvert.SerializeObject(model);

            // StringContent kullanarak JSON içeriğini HttpContent'e dönüştürün
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // HTTP POST isteği yapın ve HttpContent'i kullanın
            var response = await client.PostAsync(apiURL, httpContent);


            return Ok(response);
        }


        [HttpGet]
        [Route("Account/Logout/{id}")]
        public async Task<IActionResult> Logout(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "http://localhost:3798/api/UserLoginRegister/logout";

            var model = new LogoutRequest();
            model.Id = id;
            var jsonContent = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiURL, httpContent);

            if (response.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync();
                return Ok(response);
            }
            else
            {
                // Hata durumunda uygun bir işlem yapın
                return StatusCode((int)response.StatusCode, "Logout işlemi başarısız oldu.");
            }
        }
        [HttpGet]
        [Route("Account/LogoutKurum/{id}")]
        public async Task<IActionResult> LogoutKurum(int id)
        {
            var client = _clientFactory.CreateClient();

            // API URL'sini belirtin
            var apiURL = "https://localhost:44346/api/KurumLogin/logout";

            var model = new LogoutRequest();
            model.Id = id;
            var jsonContent = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiURL, httpContent);

            if (response.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync();
                return Ok(response);
            }
            else
            {
                // Hata durumunda uygun bir işlem yapın
                return StatusCode((int)response.StatusCode, "Logout işlemi başarısız oldu.");
            }
        }


        #endregion
        #region HelperModel
        /// <summary>
        /// Giriş anındaki usernameoremail inputunun kontrolünün yapıldığı alandır.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmail(string input)
        {
            // E-posta adresi kontrolü için bir Regex kullanıyoruz.
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(input, pattern);
        }
        /// <summary>
        /// CookieOluşturma Methodu Şuan
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> CookieCreate(TokenValidateDto model)
        {
            var claims = new List<Claim>
    {
         new Claim(ClaimTypes.Name, model.UserName),
         new Claim("TabloID", model.TabloID.ToString()),
         new Claim("Token", model.Token),
         new Claim("KisiImageUrl", model.KisiImageUrl),
         new Claim(ClaimTypes.Role, model.Role)
    };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return RedirectToAction("Index", "Home");
        }


        #endregion

    }
}
