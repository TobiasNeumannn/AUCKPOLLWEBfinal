using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AUCKPOLLWEB.Models
{
    public class airQuality
    {
        [Key]
        [Display(Name = "Sample ID")]
        public int ID { get; set; }
        [Display(Name = "Region ID")]
        public int regionID { get; set; }
        [Display(Name = "Collection Date")]
        [StringLength(maximumLength: 10, MinimumLength = 6)]
        public string collection_date { get; set; }
        [Display(Name = "Value")]
        [Range(maximum: 1000, minimum: 0)]
        public float value { get; set; }
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 10, MinimumLength = 2)]
        public string unit { get; set; }

        public regions Region { get; set; }
    }
}
