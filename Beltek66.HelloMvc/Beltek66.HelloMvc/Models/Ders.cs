using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beltek66.HelloMvc.Models
{
    public class Ders
    {
        public int DersId { get; set; }

        [Display(Name = "Ders Adı")]//Attribute
        public string DersAd { get; set; }

        public ICollection<OgretmenDers> OgretmenDers { get; set; }




    }


}
