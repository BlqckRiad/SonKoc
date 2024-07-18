using SonKocApp.DataAccessLayer.Abstract;
using SonKocApp.DataAccessLayer.Concrete;
using SonKocApp.DataAccessLayer.Repository;
using SonKocApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.DataAccessLayer.EntityFramework
{
    public class EfKurumDal : GenericRepository<Kurum>, IKurumDal
    {
        public EfKurumDal(Context context) : base(context)
        {

        }
    }
}
