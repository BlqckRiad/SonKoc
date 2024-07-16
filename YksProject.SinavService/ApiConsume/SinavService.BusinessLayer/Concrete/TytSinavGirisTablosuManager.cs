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

    public class TytSinavGirisTablosuManager : ITytSinavGirisTablosuService
    {
        private readonly ITytSinavGirisTablosuDal _sinavDal;
        public TytSinavGirisTablosuManager(ITytSinavGirisTablosuDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(TytSinavGirisTablosu entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(TytSinavGirisTablosu id)
        {
            _sinavDal.Delete(id);
        }

        public TytSinavGirisTablosu TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<TytSinavGirisTablosu> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(TytSinavGirisTablosu entity)
        {
            _sinavDal.Update(entity);
        }
    }

}
