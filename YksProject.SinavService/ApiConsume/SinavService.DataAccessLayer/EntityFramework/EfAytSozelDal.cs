using SinavService.DataAccessLayer.Abstract;
using SinavService.DataAccessLayer.Concrete;
using SinavService.DataAccessLayer.Repository;
using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DataAccessLayer.EntityFramework
{
  
    public class EfAytSozelDal : GenericRepository<AytSozelGirisTablosu>, IAytSozelDal
    {
        public EfAytSozelDal(Context context) : base(context)
        {

        }
    }
}
