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
    public class BildirimlerManager : IBildirimlerService
    {
        private readonly IBildirimlerDal _abonelikDal;

        public BildirimlerManager(IBildirimlerDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(Bildirimler entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(Bildirimler id)
        {
            _abonelikDal.Delete(id);
        }

        public Bildirimler TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<Bildirimler> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(Bildirimler entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
