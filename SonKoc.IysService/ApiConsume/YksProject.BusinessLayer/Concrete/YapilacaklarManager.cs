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
    public class YapilacaklarManager : IYapilacaklarService
    {
        private readonly IYapilacaklarDal _yapilacaklarDal;
        public YapilacaklarManager(IYapilacaklarDal yapilacaklarDal)
        {
            _yapilacaklarDal = yapilacaklarDal;
        }
        public void TAdd(Yapilacaklar entity)
        {
            _yapilacaklarDal.Add(entity);
        }

        public void TDelete(Yapilacaklar id)
        {
            _yapilacaklarDal.Delete(id);
        }

        public Yapilacaklar TGetByid(int id)
        {
            return _yapilacaklarDal.GetByid(id);
        }

        public List<Yapilacaklar> TGetList()
        {
            return _yapilacaklarDal.GetList();
        }

        public void TUpdate(Yapilacaklar entity)
        {
            _yapilacaklarDal.Update(entity);
        }
    }
}
