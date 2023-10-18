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
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string region_name { get; set; }
        [Display(Name = "Population")]
        [Range(maximum: 1000000, minimum: 1)]
        public int region_pop { get; set; }

        // Points to the children tables, the quality tables - allows other tables to take foreign keys from this table.
        public ICollection<airQuality> airQualities { get; set; }
        public ICollection<estuaryQuality> estuaryQualities { get; set; }
        public ICollection<gWaterQuality> gWaterQualities { get; set; }
    }
}
