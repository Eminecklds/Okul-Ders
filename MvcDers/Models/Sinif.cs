using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class Sinif
    {
        [Key]
        public int SinifID { get; set; }
        [Required]
        public string SinifAdi { get; set; }
        public virtual List<Ogrenci> Ogrenci { get; set; }

        public virtual List<Ders> Ders { get; set; }
    }
}