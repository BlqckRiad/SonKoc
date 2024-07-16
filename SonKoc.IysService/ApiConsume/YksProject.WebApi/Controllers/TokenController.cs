using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YksProject.WebApi.Service;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly ITokenCreateService _tokenCreateService;
        public TokenController(ITokenCreateService tokenCreateService)
        {
            _tokenCreateService = tokenCreateService;
        }
        [HttpGet("[action]")]
        public IActionResult GetTokenforUser() 
        {
            return Ok(_tokenCreateService.CreateTokenforUser());
        }
        [HttpGet("[action]")]
        public IActionResult GetTokenForAdmin()
        {
            return Ok(_tokenCreateService.CreateTokenforAdmin());
        }
        [HttpGet("[action]")]
        public IActionResult GetTokenForVisitor()
        {
            return Ok(_tokenCreateService.CreateTokenforVisitor());
        }
        [HttpGet("[action]")]
        public IActionResult GetTokenForKurum()
        {
            return Ok(_tokenCreateService.CreateTokenforKurum());
        }
        [HttpGet("[action]")]
        public IActionResult GetTokenForOgretmen()
        {
            return Ok(_tokenCreateService.CreateTokenforOgretmen());
        }
       
    }
}
