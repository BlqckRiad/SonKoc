using KurumService.DataAccessLayer.Abstract;
using KurumService.DataAccessLayer.Concrete;
using KurumService.DataAccessLayer.Repository;
using KurumService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumService.DataAccessLayer.EntityFramework
{
   
    public class EfKurumDal : GenericRepository<Kurum>, IKurumDal
    {
        public EfKurumDal(Context context) : base(context)
        {

        }
    }
}
