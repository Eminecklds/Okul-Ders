using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenID { get; set; }
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
        [Required]
        public string Bransi { get; set; }
        public int DersID { get; set; }
        //bir öğretmenin bir dersi olur
        public virtual Ders Ders { get; set; }
        public virtual List<OgrenciDers> OgrenciDers { get; set; }

    }
}