using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class OgrenciDersViewModel
    {
        public int OkulNo { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string DersAdi { get; set; }
        public string OgretmenAdi { get; set; }
        public string OgretmenSoyadi { get; set; }
        public string DerOgr { get; set; }
        public int DerID { get; set; }
        public ICollection<Ders> Ders { get; set; }
        public int OgrenciID { get; set; }
        public ICollection<Ogrenci> Ogrencis { get; set; }
        public ICollection<Ogretmen> Ogretmens { get; set; }
    }
}