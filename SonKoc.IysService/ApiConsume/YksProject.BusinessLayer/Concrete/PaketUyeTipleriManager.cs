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
    public class PaketUyeTipleriManager :IPaketUyeTipleriService
    {
        private readonly IPaketUyeTipleriDal _abonelikDal;

        public PaketUyeTipleriManager(IPaketUyeTipleriDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(PaketUyeTipleri entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(PaketUyeTipleri id)
        {
            _abonelikDal.Delete(id);
        }

        public PaketUyeTipleri TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<PaketUyeTipleri> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(PaketUyeTipleri entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
