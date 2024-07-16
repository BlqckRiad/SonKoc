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
    public class SinavTipleriManager : ISinavTipleriService
    {
        private readonly ISinavTipleriDal _sinavDal;
        public SinavTipleriManager(ISinavTipleriDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(SinavTipleri entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(SinavTipleri id)
        {
            _sinavDal.Delete(id);
        }

        public SinavTipleri TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<SinavTipleri> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(SinavTipleri entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
