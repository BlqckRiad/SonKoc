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
    public class HomePostManager : IHomePostService
    {
        private readonly IHomePostDal _abonelikDal;

        public HomePostManager(IHomePostDal abonelikdal)
        {
            _abonelikDal = abonelikdal;
        }
        public void TAdd(HomePost entity)
        {
            _abonelikDal.Add(entity);
        }

        public void TDelete(HomePost id)
        {
            _abonelikDal.Delete(id);
        }

        public HomePost TGetByid(int id)
        {
            return _abonelikDal.GetByid(id);
        }

        public List<HomePost> TGetList()
        {
            return _abonelikDal.GetList();
        }

        public void TUpdate(HomePost entity)
        {
            _abonelikDal.Update(entity);
        }
    }
}
