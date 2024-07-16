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
    public class KonularManager : IKonularService
    {
        private readonly IKonularDal _abonelikDal;

        public KonularManager(IKonularDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(Konular entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(Konular id)
        {
            _abonelikDal.Delete(id);
        }

        public Konular TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<Konular> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(Konular entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
