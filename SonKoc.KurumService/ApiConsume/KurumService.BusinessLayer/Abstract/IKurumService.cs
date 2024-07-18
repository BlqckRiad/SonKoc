using KurumService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumService.BusinessLayer.Abstract
{
    
    public interface IKurumService : IGenericService<Kurum>
    {
        Kurum GetKurumWithUsername(string username);
        Kurum GetKurumWithEmail(string email);

        Kurum GetKurumWithEmailOrUserName(string emailOrUserName);
    }
}
