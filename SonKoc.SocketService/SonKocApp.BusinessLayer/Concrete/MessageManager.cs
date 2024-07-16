using SonKocApp.BusinessLayer.Abstract;
using SonKocApp.DataAccessLayer.Abstract;
using SonKocApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.BusinessLayer.Concrete
{
   
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageService;

        public MessageManager(IMessageDal messageService)
        {
            _messageService = messageService;
        }

        public Message GetMessageWith2ID(int alici, int gonderici)
        {
            return _messageService.GetList().FirstOrDefault(x => (x.MesajGondericiID == gonderici && x.MesajAliciID == alici) ||
            (x.MesajGondericiID == alici && x.MesajAliciID == gonderici));
        }
        public void TAdd(Message entity)

        {
            _messageService.Add(entity);
        }

        public void TDelete(Message id)
        {
            _messageService.Delete(id);
        }

        public Message TGetByid(int id)
        {
            return _messageService.GetByid(id);
        }

        public List<Message> TGetList()
        {
            return _messageService.GetList().Where(x => x.SilindiMi == false).ToList();

        }

        public void TUpdate(Message entity)
        {
            _messageService.Update(entity);
        }
    }
}








