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
    public class AytEaManager : IAytEaService
    {
        private readonly IAytEaDal _sinavDal;
        public AytEaManager(IAytEaDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytEaGirisTablosu entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytEaGirisTablosu id)
        {
            _sinavDal.Delete(id);
        }

        public AytEaGirisTablosu TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytEaGirisTablosu> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytEaGirisTablosu entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
