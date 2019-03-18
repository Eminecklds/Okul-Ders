using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDers.Models
{
    public class OgrenciDers
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Öğrenci Adı")]
        public int OgrenciID { get; set; }
        [DisplayName("Ders-Öğretmen")]
        public int DerID { get; set; }
        [DisplayName("Ders-Öğretmen")]
        public string DerOgr { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
        //public virtual Ders Ders { get; set; }
    }
}