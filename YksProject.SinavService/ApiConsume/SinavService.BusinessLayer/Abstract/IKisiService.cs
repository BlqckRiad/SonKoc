using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.BusinessLayer.Abstract
{
    public interface IKisiService : IGenericService<Kisi>
    {
        Kisi GetKisiWithUsername(string username);
        Kisi GetKisiWithEmail(string email);
        string GetPhotoUrlWithID(int id);
        IEnumerable<Kisi> GetKisiWithShortUserName(string shortusername);

    }
}
