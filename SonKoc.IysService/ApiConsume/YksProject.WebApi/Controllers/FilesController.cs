using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.Dtos;
using YksProject.EntityLayer.Concrete;
using YksProject.WebApi.Service;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FilesController : ControllerBase
    {
        private readonly IMedyaKutuphanesiService _medyaKutuphanesiService;
        private readonly ITokenCreateService _tokenCreateService;
        public FilesController(IMedyaKutuphanesiService medyaKutuphanesiService, ITokenCreateService tokenCreateService)
        {
            _medyaKutuphanesiService = medyaKutuphanesiService;
            _tokenCreateService = tokenCreateService;
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(MedyaKutuphanesi model)
        {
            model.MedyaUrl = "http://localhost:6079/img/" + model.MedyaAdi;
            _medyaKutuphanesiService.TAdd(model);

            var sonEklenenData = _medyaKutuphanesiService.TGetList().Last();

            var returnModel = new MedyaKutuphanesiAddDto
            {
                TabloID= sonEklenenData.TabloID,
                MedyaUrl = model.MedyaUrl,
                MedyaAdi= model.MedyaAdi,
            };
            return Ok(returnModel);
        }
        [HttpPost("Silme")]
        public IActionResult DeleteFile(DeleteDto model)
        {
            var values = _medyaKutuphanesiService.TGetByid(model.TabloID);
            values.SilinmeTarihi = DateTime.Now;
            values.SilindiMi = true;
            values.SilenKisiID = model.SilenKisiID;
            _medyaKutuphanesiService.TUpdate(values);
            return Ok();
        }
        [HttpDelete("DeleteMedyaWithUrl")]
        public IActionResult DeleteMedyaWithUrl(string url)
        {
            _tokenCreateService.DeleteMedyaWithUrl(url);
            return Ok();
        }
    }
}
