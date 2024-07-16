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
    public class UyelikPaketleriManager : IUyelikPaketleriService
    {
        private readonly IUyelikPaketleriDal _abonelikDal;

        public UyelikPaketleriManager(IUyelikPaketleriDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(UyelikPaketleri entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(UyelikPaketleri id)
        {
            _abonelikDal.Delete(id);
        }

        public UyelikPaketleri TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<UyelikPaketleri> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(UyelikPaketleri entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
