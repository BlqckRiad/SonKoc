using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinavService.BusinessLayer.Abstract;
using SinavService.DtoLayer.DtosForUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SinavService.SinavApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class HedefHelperController : ControllerBase
    {
        private readonly IHedefGenelTanimlariService _genelTanimlariService;
        private readonly ITytHedefService _tytHedefService;
        private readonly ITytSinavGirisTablosuService _tytSinavGirisTablosuService;
        private readonly IAytSayHedefService _aytSayHedefService;
        private readonly IAytSayService _aytsayservice;
        private readonly IAytSozelHedefService _aytSozelHedefService;
        private readonly IAytSozelService _aytsozelservice;
        private readonly IAytEaHedefService _aytEahedefService;
        private readonly IAytEaService _ayteaservice;
        private readonly IAytYdHedefService _aytYdHedefService;
        private readonly IAytDilService _aytydservice;
        private readonly IKisiService _kisiService;

        public HedefHelperController(IHedefGenelTanimlariService hedefGenelTanimlariService, ITytHedefService tytHedefService, IAytSayHedefService aytSayService
            , IAytSozelHedefService aytSozelService, IAytEaHedefService aytEaService, IAytYdHedefService aytYdHedefService, IKisiService kisiService,
             ITytSinavGirisTablosuService tytSinavGirisTablosuService,
             IAytSayService aytSay,
            IAytSozelService aytSozel,
            IAytEaService easervice, IAytDilService aytydservice)
        {
            _genelTanimlariService = hedefGenelTanimlariService;
            _tytHedefService = tytHedefService;
            _aytEahedefService = aytEaService;
            _aytSayHedefService = aytSayService;
            _aytSozelHedefService = aytSozelService;
            _aytYdHedefService = aytYdHedefService;
            _kisiService = kisiService;
            _ayteaservice = easervice;
            _aytsozelservice = aytSozel;
            _aytsayservice = aytSay;
            _tytSinavGirisTablosuService = tytSinavGirisTablosuService;
            _aytydservice = aytydservice;
        }
        [HttpPost]
        public IActionResult AnaSayfaHedefDiyagramGet(AnaSayfaHedefGetDto model)
        {
            var kisibolumid = _kisiService.TGetByid(model.KisiID).KisiBolumID;

            #region HedefToplamNetHesaplama




            var kisitythedefi = _tytHedefService.TGetList()
           .Where(x => x.OlusturanKisiID == model.KisiID && x.SilindiMi == false)
           .SingleOrDefault();
            double kisitythedefitoplamnet = kisitythedefi?.HedefToplamNet ?? 0.0;


            double kisitoplamhedefnet = kisitythedefitoplamnet;
            double kisiaythedefitoplamnet = 0;
            if (kisibolumid == 1)
            {
                var kisiaythedefi = _aytSayHedefService.TGetList()
                     .Where(x => x.OlusturanKisiID == model.KisiID && x.SilindiMi == false)
                     .SingleOrDefault();
                if(kisiaythedefi !=null)
                {
                    kisiaythedefitoplamnet = kisiaythedefi.HedefToplamNet;
                }
                else
                {
                    kisiaythedefitoplamnet = 0;
                }
                
            }
            else if (kisibolumid == 2)
            {
                var kisiaythedefi = _aytEahedefService.TGetList()
                  .Where(x => x.OlusturanKisiID == model.KisiID && x.SilindiMi == false)
                  .SingleOrDefault();
                if (kisiaythedefi != null)
                {
                    kisiaythedefitoplamnet = kisiaythedefi.HedefToplamNet;
                }
                else
                {
                    kisiaythedefitoplamnet = 0;
                }
            }
            else if (kisibolumid == 3)
            {
                var kisiaythedefi = _aytSozelHedefService.TGetList()
                  .Where(x => x.OlusturanKisiID == model.KisiID && x.SilindiMi == false)
                  .SingleOrDefault();
                if (kisiaythedefi != null)
                {
                    kisiaythedefitoplamnet = kisiaythedefi.HedefToplamNet;
                }
                else
                {
                    kisiaythedefitoplamnet = 0;
                }
            }
            else if (kisibolumid == 4)
            {
                var kisiaythedefi = _aytYdHedefService.TGetList()
                  .Where(x => x.OlusturanKisiID == model.KisiID && x.SilindiMi == false)
                  .SingleOrDefault();
                if (kisiaythedefi != null)
                {
                    kisiaythedefitoplamnet = kisiaythedefi.HedefToplamNet;
                }
                else
                {
                    kisiaythedefitoplamnet = 0;
                }
            }
            else
            {
                return BadRequest("Kişi bölümü bulunamadı");
            }
            #endregion
            kisitoplamhedefnet += kisiaythedefitoplamnet;

            var baslangicYili = DateTime.Now.Year; // Yılı buradan dinamik olarak ya da modelden alın
            var baslangicAy = model.BaslangicAyi;

            var mainPageLastGoalDtoList = new List<MainPageLastGoalDto>();

            for (int haftaId = 1; haftaId <= 8; haftaId++)
            {
                var baslangicTarihi = new DateTime(baslangicYili, baslangicAy, 1).AddDays((haftaId - 1) * 7);
                var bitisTarihi = baslangicTarihi.AddDays(7).AddSeconds(-1);

                var kisitytdenemelerilist = _tytSinavGirisTablosuService.TGetList()
                    .Where(x => x.OlusturanKisiID == model.KisiID &&
                                x.OlusturulmaTarihi >= baslangicTarihi &&
                                x.OlusturulmaTarihi <= bitisTarihi &&
                                x.SilindiMi == false)
                    .ToList();
                double kisianliktoplamnet = 0;
                if (kisitytdenemelerilist != null && kisitytdenemelerilist.Any())
                {
                    var kisiTytModel = new KisiTytModelForHedefUI
                    {
                        TytTurkceNetSayisi = kisitytdenemelerilist.Any() ? kisitytdenemelerilist.Average(x => x.TytTurkceNetSayisi) : 0,
                        TytMatematikNetSayisi = kisitytdenemelerilist.Any() ? kisitytdenemelerilist.Average(x => x.TytMatematikNetSayisi) : 0,
                        TytFenNetSayisi = kisitytdenemelerilist.Any() ? kisitytdenemelerilist.Average(x => x.TytFenNetSayisi) : 0,
                        TytSosyalNetSayisi = kisitytdenemelerilist.Any() ? kisitytdenemelerilist.Average(x => x.TytSosyalNetSayisi) : 0
                    };

                    var kisianliktytnet = kisiTytModel.TytTurkceNetSayisi + kisiTytModel.TytMatematikNetSayisi + kisiTytModel.TytFenNetSayisi + kisiTytModel.TytSosyalNetSayisi;
                    kisianliktoplamnet = kisianliktytnet;
                }





                if (kisibolumid == 1)
                {
                    var kisiaytdenemelerilist = _aytsayservice.TGetList()
                        .Where(x => x.OlusturanKisiID == model.KisiID &&
                                    x.OlusturulmaTarihi >= baslangicTarihi &&
                                    x.OlusturulmaTarihi <= bitisTarihi &&
                                    x.SilindiMi == false)
                        .ToList();

                    if (kisiaytdenemelerilist != null && kisiaytdenemelerilist.Any())
                    {
                        // AYT Sayısal için net hesaplaması
                        var matNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytMatNetSayisi ) : 0;
                        var fizikNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytFizikNetSayisi) : 0;
                        var kimyaNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytKimyaNetSayisi) : 0;
                        var biyolojiNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytBiyolojiNetSayisi) : 0;

                        var toplamNetOrtalama = matNetOrtalama + fizikNetOrtalama + kimyaNetOrtalama + biyolojiNetOrtalama;
                        kisianliktoplamnet += toplamNetOrtalama;
                    }
                    else
                    {
                        kisianliktoplamnet += 0;
                    }
                }

                else if (kisibolumid == 2)
                {
                    var kisiaytdenemelerilist = _ayteaservice.TGetList()
                        .Where(x => x.OlusturanKisiID == model.KisiID &&
                                    x.OlusturulmaTarihi >= baslangicTarihi &&
                                    x.OlusturulmaTarihi <= bitisTarihi &&
                                    x.SilindiMi == false)
                        .ToList();

                    if (kisiaytdenemelerilist != null)
                    {
                        var matNetOrtalama = kisiaytdenemelerilist.Average(x => x.AytMatNetSayisi);
                      
                        var edebiyatNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytEdebiyatNetSayisi) : 0;
                        var tarih1NetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytTarih1NetSayisi) : 0;
                        var cografya1NetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytCografya1NetSayisi) : 0;

                        var toplamNetOrtalama = matNetOrtalama + edebiyatNetOrtalama + tarih1NetOrtalama + cografya1NetOrtalama;
                    kisianliktoplamnet += toplamNetOrtalama;
                    }
                    else
                    {
                        kisianliktoplamnet += 0;
                    }
                }
                else if (kisibolumid == 3)
                {
                    var kisiaytdenemelerilist = _aytsozelservice.TGetList()
                        .Where(x => x.OlusturanKisiID == model.KisiID &&
                                    x.OlusturulmaTarihi >= baslangicTarihi &&
                                    x.OlusturulmaTarihi <= bitisTarihi &&
                                    x.SilindiMi == false)
                        .ToList();

                    if (kisiaytdenemelerilist != null)
                    {
                       
                        var edebiyatNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytEdebiyatNetSayisi) : 0;
                        var tarih1NetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytTarih1NetSayisi) : 0;
                        var tarih2NetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytTarih2NetSayisi) : 0;
                        var cografya1NetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytCografya1NetSayisi) : 0;

                        var cografya2NetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytCografya2NetSayisi) : 0;
                        var felsefeNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytFelsefeNetSayisi) : 0;
                        var dinNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytDinNetSayisi) : 0;
                        var toplamNetOrtalama = tarih2NetOrtalama + edebiyatNetOrtalama + tarih1NetOrtalama + cografya1NetOrtalama + cografya2NetOrtalama + felsefeNetOrtalama + dinNetOrtalama;
                    kisianliktoplamnet += toplamNetOrtalama;
                    }
                    else
                    {
                        kisianliktoplamnet += 0;
                    }
                }
                else if (kisibolumid == 4)
                {
                    var kisiaytdenemelerilist = _aytydservice.TGetList()
                        .Where(x => x.OlusturanKisiID == model.KisiID &&
                                    x.OlusturulmaTarihi >= baslangicTarihi &&
                                    x.OlusturulmaTarihi <= bitisTarihi &&
                                    x.SilindiMi == false)
                        .ToList();

                    if (kisiaytdenemelerilist != null)
                    {
                       
                        var dilNetOrtalama = kisiaytdenemelerilist.Any() ? kisiaytdenemelerilist.Average(x => x.AytDilNetSayisi) : 0;

                        kisianliktoplamnet += dilNetOrtalama;
                    }
                    else
                    {
                        kisianliktoplamnet += 0;
                    }
                }
                else
                {
                    return BadRequest("Kişi bölümü bulunamadı !!");
                }

                double hedefNet = kisitoplamhedefnet; // Bu değeri ihtiyaçlarınıza göre ayarlayın
                var yuzdeselIfade = (kisianliktoplamnet / hedefNet) * 100;
                if (double.IsNaN(yuzdeselIfade) || double.IsInfinity(yuzdeselIfade))
                {
                    yuzdeselIfade = 0; // Or handle it in another way
                }
                var hedefAciklamaMesaji = $"Hafta {haftaId} için toplam net: {kisianliktoplamnet}";

                mainPageLastGoalDtoList.Add(new MainPageLastGoalDto
                {
                    HaftaID = haftaId,
                    ToplamNet = kisianliktoplamnet,
                    HedefNet = hedefNet,
                    YuzdeselIfade = yuzdeselIfade,
                    HedefAciklamaMesaji = hedefAciklamaMesaji
                });
            }

           



            return Ok(mainPageLastGoalDtoList);
        }
    }
}
