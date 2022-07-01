using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beltek66.HelloMvc.Models
{
    public class Bolum
    {
        public int BolumId { get; set; }

        public string BolumAd { get; set; }

        public ICollection<Ogretmen> Ogretmen { get; set; }

    }
}
