using System.ComponentModel.DataAnnotations;

namespace Beltek66.HelloMvc.Models
{
    public class OgretmenDers
    {
        public int OgretmenDersId { get; set; }
        [Display(Name = "Öğretmen Adı")]//Attribute
        public int OgretmenId { get; set; }
        [Display(Name = "Öğretmen Adı")]//Attribute
        public Ogretmen Ogretmen { get; set; }
        [Display(Name = "Ders Adı")]//Attribute
        public int DersId { get; set; }
        [Display(Name = "Ders Adı")]//Attribute
        public Ders Ders { get; set; }


    }
}
