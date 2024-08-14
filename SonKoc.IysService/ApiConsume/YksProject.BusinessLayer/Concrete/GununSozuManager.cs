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
   
    public class GununSozuManager : IGununSozuService
    {
        private readonly IGununSozuDal _abonelikDal;

        public GununSozuManager(IGununSozuDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(GununSozu entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(GununSozu id)
        {
            _abonelikDal.Delete(id);
        }

        public GununSozu TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<GununSozu> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(GununSozu entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
