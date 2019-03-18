using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciID { get; set; }
        [Required]
        public int OkulNo { get; set; }
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
        public int SinifID { get; set; }
        public virtual Sinif Sinif { get; set; }
        //bir öğrencini birden fazla dersi olur
        public virtual List<OgrenciDers> OgrenciDers { get; set; }


    }
}