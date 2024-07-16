using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YksProject.EntityLayer.Concrete;

namespace YksProject.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=MILANOPC;initial catalog=YksProjesiData;user id=ps;password=12345Aa!;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True") ;
        }
        public DbSet<Abonelik> Abonelik { get; set; }
       
        public DbSet<GirilenSinav> GirilenSinav { get; set; }
        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Kurum> Kurum { get; set; }
        public DbSet<Referanslarimiz> Referanslarimiz { get; set; }
        public DbSet<Bolumler> Bolumler { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<Yapilacaklar> Yapilacaklar { get; set; }
        public DbSet<MedyaKutuphanesi> MedyaKutuphanesi { get; set; }
        public DbSet<Roller> Roller { get; set; }
        public DbSet<UyelikPaketleri> UyelikPaketleri { get; set; }
        public DbSet<PaketUyeTipleri> PaketUyeTipleri { get; set; }
        public DbSet<HomePost> HomePost { get; set; }
        public DbSet<Konular> Konular { get; set; }
        public DbSet<Bildirimler> Bildirimler { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Sinav> Sinav { get; set; }
        public DbSet<SinavTipleri> SinavTipleri { get; set; }
        public DbSet<TytSinavGirisTablosu> TytSinavGirisTablosu { get; set; }
        public DbSet<AytSayGirisTablosu> AytSayGirisTablosu { get; set; }
        public DbSet<AytEaGirisTablosu> AytEaGirisTablosu { get; set; }
        public DbSet<AytSozelGirisTablosu> AytSozelGirisTablosu { get; set; }
        public DbSet<AytYDGirisTablosu> AytYDGirisTablosu { get; set; }
    }
}
