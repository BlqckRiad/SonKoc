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
    public class EfRollerDal : GenericRepository<Roller>, IRollerDal
    {
        public EfRollerDal(Context context) : base(context)
        {

        }
    }
}
