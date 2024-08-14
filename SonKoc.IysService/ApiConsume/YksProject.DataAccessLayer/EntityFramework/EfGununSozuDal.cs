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
   
    public class EfGununSozuDal : GenericRepository<GununSozu>, IGununSozuDal
    {
        public EfGununSozuDal(Context context) : base(context)
        {

        }
    }
}
