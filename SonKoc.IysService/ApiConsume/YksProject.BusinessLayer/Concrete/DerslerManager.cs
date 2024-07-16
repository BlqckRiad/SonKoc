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
    public class DerslerManager : IDerslerService
    {
        private readonly IDerslerDal _derslerDal;
        public DerslerManager(IDerslerDal service)
        {
            _derslerDal = service;
        }
        public void TAdd(Dersler entity)
        {
            _derslerDal.Add(entity);
        }

        public void TDelete(Dersler id)
        {
            _derslerDal.Delete(id);
        }

        public Dersler TGetByid(int id)
        {
            return _derslerDal.GetByid(id);
        }

        public List<Dersler> TGetList()
        {
            return _derslerDal.GetList();
        }

        public void TUpdate(Dersler entity)
        {
            _derslerDal.Update(entity);
        }
    }
}
