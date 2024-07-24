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
   
    public class TytHedefManager : ITytHedefService
    {
        private readonly ITytHedefDal _sinavDal;
        public TytHedefManager(ITytHedefDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(TytHedef entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(TytHedef id)
        {
            _sinavDal.Delete(id);
        }

        public TytHedef TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<TytHedef> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(TytHedef entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
