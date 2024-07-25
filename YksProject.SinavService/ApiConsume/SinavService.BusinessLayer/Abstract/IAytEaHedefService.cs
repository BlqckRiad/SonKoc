using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.BusinessLayer.Abstract
{

    public interface IAytEaHedefService : IGenericService<AytEaHedef>
    {
        public AytEaHedef GetLatest();
    }
}
