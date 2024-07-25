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
   
    public class AytSozelHedefManager : IAytSozelHedefService
    {
        private readonly IAytSozelHedefDal _sinavDal;
        public AytSozelHedefManager(IAytSozelHedefDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytSozelHedef entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytSozelHedef id)
        {
            _sinavDal.Delete(id);
        }

        public AytSozelHedef TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytSozelHedef> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytSozelHedef entity)
        {
            _sinavDal.Update(entity);
        }
        public AytSozelHedef GetLatest()
        {
            return _sinavDal.GetList()
                            .OrderByDescending(x => x.OlusturulmaTarihi)
                            .FirstOrDefault();
        }
    }
}
