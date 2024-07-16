using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YksProject.BusinessLayer.Abstract;
using YksProject.DataAccessLayer.Abstract;
using YksProject.EntityLayer.Concrete;

namespace YksProject.BusinessLayer.Concrete
{
    public class AbonelikManager : IAbonelikService
    {
        private readonly IAbonelikDal _abonelikDal;

        public AbonelikManager(IAbonelikDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(Abonelik entity)
        {
           _abonelikDal.Add(entity);
        }

        public void TDelete(Abonelik id)
        {
            _abonelikDal.Delete(id);
        }

        public Abonelik TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<Abonelik> TGetList()
        {
          return _abonelikDal.GetList();
        }

        public void TUpdate(Abonelik entity)
        {
          _abonelikDal.Update(entity);
        }
    }
}
