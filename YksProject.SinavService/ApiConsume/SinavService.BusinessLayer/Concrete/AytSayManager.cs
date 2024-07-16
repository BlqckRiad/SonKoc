using SinavService.BusinessLayer.Abstract;
using SinavService.DataAccessLayer.Abstract;
using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.BusinessLayer.Concrete
{
    public class AytSayManager : IAytSayService
    {
        private readonly IAytSayDal _sinavDal;
        public AytSayManager(IAytSayDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytSayGirisTablosu entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytSayGirisTablosu id)
        {
            _sinavDal.Delete(id);
        }

        public AytSayGirisTablosu TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytSayGirisTablosu> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytSayGirisTablosu entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
