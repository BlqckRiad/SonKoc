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
   
    public class AytEaHedefManager : IAytEaHedefService
    {
        private readonly IAytEaHedefDal _sinavDal;
        public AytEaHedefManager(IAytEaHedefDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytEaHedef entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytEaHedef id)
        {
            _sinavDal.Delete(id);
        }

        public AytEaHedef TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytEaHedef> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytEaHedef entity)
        {
            _sinavDal.Update(entity);
        }
    }
}
