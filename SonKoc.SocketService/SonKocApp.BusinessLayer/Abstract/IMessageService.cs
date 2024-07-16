using SonKocApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.BusinessLayer.Abstract
{
   
    public interface IMessageService : IGenericService<Message>
    {
        Message GetMessageWith2ID(int alici, int gonderici);
    }
}
