using SonKocApp.BusinessLayer.Abstract;
using SonKocApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.BusinessLayer.Concrete
{
    public class KurumManager : IKurumService
    {
        private readonly IKurumDal _kisiDal;

        public KurumManager(IKurumDal kisiDal)
        {
            _kisiDal = kisiDal;
        }
        public void TAdd(Kurum entity)
        {
            _kisiDal.Add(entity);
        }

        public void TDelete(Kurum id)
        {
            _kisiDal.Delete(id);
        }

        public Kurum TGetByid(int id)
        {
            return _kisiDal.GetByid(id);
        }

        public List<Kurum> TGetList()
        {
            return _kisiDal.GetList();
        }

        public void TUpdate(Kurum entity)
        {
            _kisiDal.Update(entity);
        }
        public Kurum GetKurumWithUsername(string username)
        {
            return _kisiDal.GetList().FirstOrDefault(x => x.KurumAdi == username);
        }

        public Kurum GetKurumWithEmail(string email)
        {
            return _kisiDal.GetList().FirstOrDefault(x => x.KurumEmail == email);
        }
        public Kurum GetKurumWithEmailOrUserName(string data)
        {
            return _kisiDal.GetList().FirstOrDefault(x => x.KurumEmail == data || x.KurumAdi == data);
        }


    }
}
