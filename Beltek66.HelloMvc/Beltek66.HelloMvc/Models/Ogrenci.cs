using System.ComponentModel.DataAnnotations;

namespace Beltek66.HelloMvc.Models
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        [Display(Name = "Ad")]//Attribute
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [Display(Name = "Ad Soyad")]
        public string FullName => string.Concat(Ad, " ", Soyad);

        [Display(Name ="Yaş")]
        public byte Yas { get; set; }

        [Display(Name = "Sınıf")]
        public int SinifId { get; set; }

        //Navigtion Property
        [Display(Name = "Sınıf")]
        public Sinif Sinifi { get; set; }



    }
}
