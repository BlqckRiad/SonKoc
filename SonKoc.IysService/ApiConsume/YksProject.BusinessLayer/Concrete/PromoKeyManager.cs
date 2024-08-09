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
    
    public class PromoKeyManager : IPromoKeyService
    {
        private readonly IPromoKeyDal _abonelikDal;

        public PromoKeyManager(IPromoKeyDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(PromoKey entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(PromoKey id)
        {
            _abonelikDal.Delete(id);
        }

        public PromoKey TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<PromoKey> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(PromoKey entity)
        {
            _abonelikDal.Update(entity);
        }
        

        public PromoKey KeyGetWitKod(string key)
        {
            return _abonelikDal.GetList().FirstOrDefault(x => x.PromoKod == key);
        }
    }
}
