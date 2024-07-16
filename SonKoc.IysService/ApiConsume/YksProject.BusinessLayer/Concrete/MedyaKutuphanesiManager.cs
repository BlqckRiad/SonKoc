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
    public class MedyaKutuphanesiManager : IMedyaKutuphanesiService
    {
        private readonly IMedyaKutuphanesiDal _medyaKutuphanesiDal;

        public MedyaKutuphanesiManager(IMedyaKutuphanesiDal medyaKutuphanesiDal)
        {
            _medyaKutuphanesiDal = medyaKutuphanesiDal;
        }
        public void TAdd(MedyaKutuphanesi entity)
        {
            _medyaKutuphanesiDal.Add(entity);
        }

        public void TDelete(MedyaKutuphanesi id)
        { 
            _medyaKutuphanesiDal.Delete(id);
        }

        public MedyaKutuphanesi TGetByid(int id)
        {
            return _medyaKutuphanesiDal.GetByid(id);
        }

        public List<MedyaKutuphanesi> TGetList()
        {
            return _medyaKutuphanesiDal.GetList();
        }

        public void TUpdate(MedyaKutuphanesi entity)
        {
            _medyaKutuphanesiDal.Update(entity);
        }

       
    }
}
