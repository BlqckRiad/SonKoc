using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using YksProject.BusinessLayer.Abstract;
using YksProject.DtoLayer.FrontendDto;
using YksProject.EntityLayer.Concrete;

namespace YksProject.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class KonularForUserController : ControllerBase
    {
        private readonly IKonularService _konularService;
        private readonly IKisiService _kisiService;
        private readonly ITamamlanmisKonularService _tamamlanmisKonularService;
        private readonly IGununSozuService _gunSozuService;


        public KonularForUserController(IKonularService konularService, IKisiService kisiService ,ITamamlanmisKonularService tamamlanmisKonularService,IGununSozuService gununSozuService)
        {
            _konularService = konularService;
            _kisiService = kisiService;
            _tamamlanmisKonularService = tamamlanmisKonularService;
            _gunSozuService = gununSozuService;
        }
        
        [HttpGet]
        public IActionResult GetKonularWithUserID(int id)
        {
            var kisibolumid = _kisiService.TGetByid(id).KisiBolumID;
            var kisitoplamkonusayisi = 0;
            if (kisibolumid == 1) //Sayısal
            {
                kisitoplamkonusayisi = _konularService.TGetList().Where(x => x.KonuDersID ==1 || x.KonuDersID == 2
                || x.KonuDersID == 3 || x.KonuDersID == 4 || x.KonuDersID == 5 || x.KonuDersID == 6 ||
                 x.KonuDersID == 7
                 || x.KonuDersID == 8
                 || x.KonuDersID == 9
                 || x.KonuDersID == 17
                 || x.KonuDersID == 18
                 || x.KonuDersID == 19
                 || x.KonuDersID == 20
                 ).Count();
            }
            else if(kisibolumid == 2) // Eşit Ağırlık
            {
                 kisitoplamkonusayisi = _konularService.TGetList().Where(x => x.KonuDersID == 1 || x.KonuDersID == 2
               || x.KonuDersID == 3 || x.KonuDersID == 4 || x.KonuDersID == 5 || x.KonuDersID == 6 ||
                x.KonuDersID == 7
                || x.KonuDersID == 8
                || x.KonuDersID == 9
                || x.KonuDersID == 17
                || x.KonuDersID == 10
                || x.KonuDersID == 11
                || x.KonuDersID == 12
                ).Count();
            }
            else if (kisibolumid == 3) // Sözel
            {
                 kisitoplamkonusayisi = _konularService.TGetList().Where(x => x.KonuDersID == 1 || x.KonuDersID == 2
               || x.KonuDersID == 3 || x.KonuDersID == 4 || x.KonuDersID == 5 || x.KonuDersID == 6 ||
                x.KonuDersID == 7
                || x.KonuDersID == 8
                || x.KonuDersID == 9
                || x.KonuDersID == 10
                || x.KonuDersID == 11
                || x.KonuDersID == 12
                || x.KonuDersID == 13
                || x.KonuDersID == 14
                || x.KonuDersID == 15
                || x.KonuDersID == 16
                ).Count();
            }
            else if (kisibolumid ==4) // Yabancı Dil
            {
                 kisitoplamkonusayisi = _konularService.TGetList().Where(x => x.KonuDersID == 1 || x.KonuDersID == 2
               || x.KonuDersID == 3 || x.KonuDersID == 4 || x.KonuDersID == 5 || x.KonuDersID == 6 ||
                x.KonuDersID == 7
                || x.KonuDersID == 8
                || x.KonuDersID == 9
                || x.KonuDersID == 21
              
                ).Count();
            }
            var kisitamamlanmiskonusayisi = _tamamlanmisKonularService.TGetList().Where(x=>x.TamamlayanKisiID==id).Count();
            var requestobject = new FrontendMainPageKonuDto();
            requestobject.TamamlanmisKonuSayisi = kisitamamlanmiskonusayisi;
            requestobject.ToplamKonuSayisi = kisitoplamkonusayisi;
            var sozler = _gunSozuService.TGetList().Where(x => x.SilindiMi == false).ToList();
            if (sozler.Any())
            {
                Random random = new Random();
                int randomIndex = random.Next(sozler.Count);
                var rastgeleSoz = sozler[randomIndex];
                requestobject.GununSozu = rastgeleSoz.Soz;
            }
            else
            {
                requestobject.GununSozu = "SonKoç ' a Hoşgeldin :)";
            }
            
            return Ok(requestobject);
        }
        [HttpPost]
        public IActionResult KisiKonuTamamlanma(KisiKonuDto model)
        {
            var kisikonu = new TamamlanmisKonular();
            kisikonu.TamamlanmaTarihi = DateTime.Now;
            kisikonu.TamamlayanKisiID = model.KisiID;
            kisikonu.KonuID = model.KonuID;
            _tamamlanmisKonularService.TAdd(kisikonu);
            return Ok();           
        }
        [HttpPost]
        public IActionResult KisiKonuSilme(KisiKonuDto model)
        {
            var kisikonuid = _tamamlanmisKonularService.TamamlanmisKonuIDGetir(model.KisiID, model.KonuID);
            _tamamlanmisKonularService.TDelete(kisikonuid);
            return Ok();
        }
    }
   
}
