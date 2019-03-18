using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class DersOgretmenViewModel
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Bransi { get; set; }
        public int DersID { get; set; }
        public string DersAdi { get; set; }
        public ICollection<Ders> Ders { get; set; }
        public ICollection<Ogretmen> Ogretmen { get; set; }
    }
}