using Microsoft.EntityFrameworkCore;
using SinavService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=MILANOPC;initial catalog=YksProjesiData;user id=ps;password=12345Aa!;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");
        }
        
        public DbSet<Sinav> Sinav { get; set; }
        public DbSet<SinavTipleri> SinavTipleri { get; set; }
        public DbSet<TytSinavGirisTablosu> TytSinavGirisTablosu { get; set; }
        public DbSet<AytSayGirisTablosu> AytSayGirisTablosu { get; set; }
        public DbSet<AytEaGirisTablosu> AytEaGirisTablosu { get; set; }
        public DbSet<AytSozelGirisTablosu> AytSozelGirisTablosu { get; set; }
        public DbSet<AytYDGirisTablosu> AytYDGirisTablosu { get; set; }
    }
}
