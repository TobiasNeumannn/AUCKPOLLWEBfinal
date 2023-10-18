using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AUCKPOLLWEB.Models
{
    public class estuaryQuality
    {
        [Key]
        [Display(Name = "Sample ID")]
        public int ID { get; set; }
        [Display(Name = "Region ID")]
        public int regionID { get; set; }
        [Display(Name = "Collection Date")]
        [DataType(DataType.Date)]
        public DateTime collection_date { get; set; }
        [Display(Name = "Indicator")]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string indicator { get; set; }
        [Display(Name = "Value")]
        [Range(maximum: 1000, minimum: 0)]
        public float value { get; set; }

        public regions Region { get; set; }
    }
}
