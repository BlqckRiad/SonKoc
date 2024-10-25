using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperService.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=MILANOPC;initial catalog=YksProjesiData;user id=ps;password=12345Aa!;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");
        }

       
    }
}
