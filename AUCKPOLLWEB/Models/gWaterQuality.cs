using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AUCKPOLLWEB.Models
{
    public class gWaterQuality
    {
        [Display(Name = "Sample ID")]
        public int ID { get; set; }
        [Display(Name = "Region ID")]
        public int regionID { get; set; }
        [Display(Name = "Collection Date")]
        [DataType(DataType.Date)] // Data annotation that makes it so the user only had to enter a date, not date and time
        public DateTime collection_date { get; set; }
        [Display(Name = "Indicator")]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string indicator { get; set; }
        [Display(Name = "Value")]
        [Range(maximum: 10000, minimum: 0)]
        public float value { get; set; }
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 10, MinimumLength = 2)]
        public string unit { get; set; }

        public regions Region { get; set; }
    }
}
