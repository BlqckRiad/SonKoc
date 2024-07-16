using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YksProject.BusinessLayer.Abstract;
using YksProject.DataAccessLayer.Abstract;
using YksProject.DataAccessLayer.EntityFramework;
using YksProject.EntityLayer.Concrete;

namespace YksProject.BusinessLayer.Concrete
{
    public class BolumlerManager : IBolumlerService
    {
        private readonly IBolumlerDal _bolumService;
        public BolumlerManager(IBolumlerDal service)
        {
            _bolumService = service;
        }
        public void TAdd(Bolumler entity)
        {
            _bolumService.Add(entity);
            
        }

        public void TDelete(Bolumler id)
        {
            _bolumService.Delete(id);
        }

        public Bolumler TGetByid(int id)
        {
            return _bolumService.GetByid(id);
        }

        public List<Bolumler> TGetList()
        {
            return _bolumService.GetList();
        }

        public void TUpdate(Bolumler entity)
        {
            _bolumService.Update(entity);
        }
    }

}
