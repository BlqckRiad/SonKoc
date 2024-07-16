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
    public class AytDilManager : IAytDilService
    {
        private readonly IAytDilDal _sinavDal;
        public AytDilManager(IAytDilDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytYDGirisTablosu entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytYDGirisTablosu id)
        {
            _sinavDal.Delete(id);
        }

        public AytYDGirisTablosu TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytYDGirisTablosu> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytYDGirisTablosu entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
