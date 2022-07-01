using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beltek66.HelloMvc.Models
{
    public class Ogretmen
    {
        public int OgretmenId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [Display(Name = "Ad Soyad")]
        public string FullName => string.Concat(Ad," ",Soyad);

        [Display(Name = "Bölüm")]//Attribute
        public int BolumId { get; set; }
        [Display(Name = "Bölüm")]//Attribute
        public Bolum Bolum { get; set; }

        [Display(Name = "Yaş")]
        public byte Yas { get; set; }

        public ICollection<OgretmenDers> OgretmenDers { get; set; }


    }
    
}
