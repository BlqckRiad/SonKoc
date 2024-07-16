using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YksProject.DataAccessLayer.Abstract;
using YksProject.DataAccessLayer.Concrete;
using YksProject.DataAccessLayer.Repository;
using YksProject.EntityLayer.Concrete;

namespace YksProject.DataAccessLayer.EntityFramework
{
   
    public class EfBildirimlerDal : GenericRepository<Bildirimler>, IBildirimlerDal
    {
        public EfBildirimlerDal(Context context) : base(context)
        {

        }
    }
}
