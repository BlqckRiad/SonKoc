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
    public class RollerManager : IRollerService
    {
        private readonly IRollerDal _rollerDal;

        public RollerManager(IRollerDal rollerDal)
        {
            _rollerDal = rollerDal;
        }
        public void TAdd(Roller entity)
        {
            _rollerDal.Add(entity);
        }

        public void TDelete(Roller id)
        {
            _rollerDal.Delete(id);
        }

        public Roller TGetByid(int id)
        {
            return _rollerDal.GetByid(id);
        }

        public List<Roller> TGetList()
        {
            return _rollerDal.GetList();
        }

        public void TUpdate(Roller entity)
        {
            _rollerDal.Update(entity);
        }
    }
}
