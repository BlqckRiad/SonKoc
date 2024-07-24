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
    
    public class HedefGenelTanimlariManager : IHedefGenelTanimlariService
    {
        private readonly IHedefGenelTanimlariDal _sinavDal;
        public HedefGenelTanimlariManager(IHedefGenelTanimlariDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(HedefGenelTanimlari entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(HedefGenelTanimlari id)
        {
            _sinavDal.Delete(id);
        }

        public HedefGenelTanimlari TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<HedefGenelTanimlari> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(HedefGenelTanimlari entity)
        {
            _sinavDal.Update(entity);
        }
        public HedefGenelTanimlari GetKisiWithUsername(int id)
        {
            return _sinavDal.GetList().FirstOrDefault(x => x.HedefYapanKisiID == id);
        }

    }
}
