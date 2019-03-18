using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class Ders
    {
        [Key]
        public int DersID { get; set; }
        [Required]
        public string DersAdi { get; set; }
        //bir dersin birden faz hocası olabilir
        public virtual List<Ogretmen> Ogretmen { get; set; }
        //bir dersin birden fazla öğrencisi var
        public virtual Sinif Sinif { get; set; }
        public virtual List<OgrenciDers> OgrenciDers { get; set; }

    }
}