using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class OkulContext:DbContext
    {
        public DbSet<Sinif> Sinifs { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
        public DbSet<Ders> Derses { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }

        public System.Data.Entity.DbSet<MvcDers.Models.OgrenciDers> OgrenciDers { get; set; }
    }
}