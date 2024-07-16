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
    public class ReferanslarimizManager : IReferanslarimizService
    {
        private readonly IReferanslarimizDal _refereDal;

        public ReferanslarimizManager(IReferanslarimizDal refereDal)
        {
            _refereDal = refereDal;
        }
        public void TAdd(Referanslarimiz entity)
        {
            _refereDal.Add(entity);
        }

        public void TDelete(Referanslarimiz id)
        {
            _refereDal.Delete(id);
        }

        public Referanslarimiz TGetByid(int id)
        {
            return _refereDal.GetByid(id);
        }

        public List<Referanslarimiz> TGetList()
        {
          return _refereDal.GetList();
        }

        public void TUpdate(Referanslarimiz entity)
        {
            _refereDal.Update(entity);
        }
    }
}
