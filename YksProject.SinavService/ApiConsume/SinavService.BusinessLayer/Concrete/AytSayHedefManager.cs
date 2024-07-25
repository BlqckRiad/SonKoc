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
  
    public class AytSayHedefManager : IAytSayHedefService
    {
        private readonly IAytSayHedefDal _sinavDal;
        public AytSayHedefManager(IAytSayHedefDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytSayHedef entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytSayHedef id)
        {
            _sinavDal.Delete(id);
        }

        public AytSayHedef TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytSayHedef> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytSayHedef entity)
        {
            _sinavDal.Update(entity);
        }
        public AytSayHedef GetLatest()
        {
            return _sinavDal.GetList()
                            .OrderByDescending(x => x.OlusturulmaTarihi)
                            .FirstOrDefault();
        }
    }
}
