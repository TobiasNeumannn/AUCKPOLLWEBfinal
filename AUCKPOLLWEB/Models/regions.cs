using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AUCKPOLLWEB.Models
{
    public class regions
    {
        [Key]
        [Display(Name = "Region ID")]
        public int regionID { get; set; }
        [Display(Name = "Name")]
        public string region_name { get; set; }
        [Display(Name = "Population")]
        public int region_pop { get; set; }

        public ICollection<airQuality> airQualities { get; set; }
        public ICollection<estuaryQuality> estuaryQualities { get; set; }
        public ICollection<gWaterQuality> gWaterQualities { get; set; }
    }
}
