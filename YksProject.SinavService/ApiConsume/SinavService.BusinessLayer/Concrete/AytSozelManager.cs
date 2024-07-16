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
    public class AytSozelManager : IAytSozelService
    {
        private readonly IAytSozelDal _sinavDal;
        public AytSozelManager(IAytSozelDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytSozelGirisTablosu entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytSozelGirisTablosu id)
        {
            _sinavDal.Delete(id);
        }

        public AytSozelGirisTablosu TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytSozelGirisTablosu> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytSozelGirisTablosu entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
