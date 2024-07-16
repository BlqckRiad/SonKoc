using SonKocApp.BusinessLayer.Abstract;
using SonKocApp.DataAccessLayer.Abstract;
using SonKocApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.BusinessLayer.Concrete
{
    public class KisiManager : IKisiService
    {
        private readonly IKisiDal _kisiDal;

        public KisiManager(IKisiDal kisiDal)
        {
            _kisiDal = kisiDal;
        }
        public void TAdd(Kisi entity)
        {
            _kisiDal.Add(entity);
        }

        public void TDelete(Kisi id)
        {
            _kisiDal.Delete(id);
        }

        public Kisi TGetByid(int id)
        {
            return _kisiDal.GetByid(id);
        }

        public List<Kisi> TGetList()
        {
            return _kisiDal.GetList();
        }

        public void TUpdate(Kisi entity)
        {
            _kisiDal.Update(entity);
        }

        public Kisi GetKisiWithUsername(string username)
        {
            return _kisiDal.GetList().FirstOrDefault(x => x.KisiKullaniciAdi == username);
        }

        public Kisi GetKisiWithEmail(string email)
        {
            return _kisiDal.GetList().FirstOrDefault(x => x.KisiEmail == email);
        }


        public string GetPhotoUrlWithID(int id)
        {
            var kisi = _kisiDal.GetByid(id);
            if (kisi != null)
            {
                return kisi.KisiImageUrl;
            }
            var basic = "https://w7.pngwing.com/pngs/696/429/png-transparent-computer-icons-user-account-colombo-filippetti-spa-human-icon-share-icon-artwork-user-account.png";
            return basic;
        }

        public IEnumerable<Kisi> GetKisiWithShortUserName(string shortusername)
        {
            return _kisiDal.GetList().Where(kisi => kisi.KisiKullaniciAdi.StartsWith(shortusername, StringComparison.OrdinalIgnoreCase));
        }

    }
}
