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

    public class AytYdHedefManager : IAytYdHedefService
    {
        private readonly IAytYdHedefDal _sinavDal;
        public AytYdHedefManager(IAytYdHedefDal sinavDal)
        {
            _sinavDal = sinavDal;
        }
        public void TAdd(AytYdHedef entity)
        {
            _sinavDal.Add(entity);
        }

        public void TDelete(AytYdHedef id)
        {
            _sinavDal.Delete(id);
        }

        public AytYdHedef TGetByid(int id)
        {
            return _sinavDal.GetByid(id);
        }

        public List<AytYdHedef> TGetList()
        {
            return _sinavDal.GetList();
        }

        public void TUpdate(AytYdHedef entity)
        {
            _sinavDal.Update(entity);
        }
        public AytYdHedef GetLatest()
        {
            return _sinavDal.GetList()
                            .OrderByDescending(x => x.OlusturulmaTarihi)
                            .FirstOrDefault();
        }
    }
}
