using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YksProject.BusinessLayer.Abstract;
using YksProject.DataAccessLayer.Abstract;
using YksProject.DataAccessLayer.EntityFramework;
using YksProject.EntityLayer.Concrete;

namespace YksProject.BusinessLayer.Concrete
{
    
    public class TamamlanmisKonularManager : ITamamlanmisKonularService
    {
        private readonly ITamamlanmisKonularDal _abonelikDal;

        public TamamlanmisKonularManager(ITamamlanmisKonularDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(TamamlanmisKonular entity)
        {
            _abonelikDal.Add(entity);
        }

        public TamamlanmisKonular TamamlanmisKonuIDGetir(int kisiid, int konuid)
        {
           
                return _abonelikDal.GetList().FirstOrDefault(x => x.KonuID == konuid && x.TamamlayanKisiID == kisiid);
           
        }

        public void TDelete(TamamlanmisKonular id)
        {
            _abonelikDal.Delete(id);
        }

        public TamamlanmisKonular TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<TamamlanmisKonular> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(TamamlanmisKonular entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
