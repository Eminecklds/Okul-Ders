using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class OgrenciSinifViewModel
    {
        [Key]
        public int ID { get; set; }
        public int OkulNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int SinifID { get; set; }
        public string Sinifi { get; set; }
        public ICollection<Sinif> Sinif { get; set; }
        public ICollection<Ogrenci> Ogrenci { get; set; }
    }
}