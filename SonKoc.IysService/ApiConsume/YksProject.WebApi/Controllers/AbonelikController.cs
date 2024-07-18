using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YksProject.BusinessLayer.Abstract;
using YksProject.EntityLayer.Concrete;

namespace YksProject.YksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [AllowAnonymous]
    public class AbonelikController : ControllerBase
    {
        private readonly IAbonelikService _abonelikService;
        public AbonelikController(IAbonelikService abonelikService)
        {
            _abonelikService = abonelikService;
        }
        [HttpGet]
        public IActionResult ListAbonelik()
        {
            var result = _abonelikService.TGetList();
            
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbonelik(int id)
        {
            var values = _abonelikService.TGetByid(id);
            _abonelikService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbonelik(Abonelik model)
        {
            _abonelikService.TUpdate(model);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddAbonelik(Abonelik model)
        {
            _abonelikService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbonelik(int id)
        {
            var result = _abonelikService.TGetByid(id);
            
            return Ok(result);
        }
        //https://www.youtube.com/watch?v=Ke50yA-rdrM
    }
}
