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
    public class SinavManager : ISinavService
    {
        private readonly ISinavDal _sinavDal;
        public SinavManager(ISinavDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(Sinav entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(Sinav id)
        {
            _sinavDal.Delete(id);
        }

        public Sinav TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<Sinav> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(Sinav entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
