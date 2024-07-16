using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;
using System.Linq;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HomePostController : ControllerBase
    {
        private readonly IHomePostService _homePostService;
        public HomePostController(IHomePostService homePostService)
        {
            _homePostService = homePostService;
        }
        [HttpGet("ForAdmin")]
        public ActionResult<List<HomePost>> ListHomePostForAdmin()
        {
            var result = _homePostService.TGetList().Where(x => x.SilindiMi == false).ToList();
            return result;
        }
        [HttpGet("ForMain")]
        public ActionResult<List<HomePost>> ListHomePostForMain()
        {
            var results = _homePostService.TGetList().Where(x => x.SilindiMi == false).ToList();
            results.ForEach(x => x.PostGorulmeSayisi += 1);

            // Değişiklikleri veri tabanına kaydetmek için
            foreach (var result in results)
            {
                _homePostService.TUpdate(result);
            }

            return results;

        }
        [HttpPost("Silme")]
        public IActionResult DeleteHomePost(DeleteDto model)
        {
            var values = _homePostService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _homePostService.TUpdate(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateHomePost(HomePost model)
        {
            var result = _homePostService.TGetByid(model.TabloID);
            result.PostAdi = model.PostAdi;
            result.PostAciklamasi = model.PostAciklamasi;
            result.PostSahibi = model.PostSahibi;
            result.PostMedyaID= model.PostMedyaID;
            result.PostMedyaUrl = model.PostMedyaUrl;
            result.PostYayindaMi = model.PostYayindaMi;
            result.GuncellenmeTarihi = DateTime.Now;
            result.GuncelleyenKisiID = model.GuncelleyenKisiID;
            _homePostService.TUpdate(result);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddHomePost(HomePost model)
        {
           model.OlusturulmaTarihi = DateTime.Now;
            _homePostService.TAdd(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<HomePost> GetHomePost(int id)
        {
            var result = _homePostService.TGetByid(id);
            if (result.SilindiMi == false)
            {
                if (result != null)
                {

                   
                    return result;
                }
                return BadRequest("HomePost Bulunamadı.");
            }
           return BadRequest("HomePost Degeri Silinmis.");
            
        }
        [HttpGet("Main/{id}")]
        public ActionResult<HomePost> GetHomePostForMain(int id)
        {
            var result = _homePostService.TGetByid(id);
            if (result.SilindiMi != true)
            {
                if (result != null)
                {
                    result.PostGorulmeSayisi += 1;
                    result.PostTiklanmaSayisi += 1;

                    _homePostService.TUpdate(result);
                    return result;
                }
                return BadRequest("HomePost Bulunamadı.");
            }
            return BadRequest("HomePost Degeri Silinmis.");

        }
    }
}
