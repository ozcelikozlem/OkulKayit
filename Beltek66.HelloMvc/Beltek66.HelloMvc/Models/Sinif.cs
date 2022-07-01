using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beltek66.HelloMvc.Models
{
    public class Sinif
    {
        [Display(Name = "Sınıf Ad")]//Attribute
        public int SinifId { get; set; }

        [Display(Name = "Sınıf Ad")]//Attribute
        public string SinifAd { get; set; }

        public ICollection<Ogrenci> Ogenciler { get; set; }

    }
}
