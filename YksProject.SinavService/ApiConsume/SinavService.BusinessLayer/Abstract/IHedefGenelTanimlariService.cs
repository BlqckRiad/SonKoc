using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.BusinessLayer.Abstract
{
   
    public interface IHedefGenelTanimlariService : IGenericService<HedefGenelTanimlari>
    {
        HedefGenelTanimlari GetHedefWithUserID(int id);
    }
}
