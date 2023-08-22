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
        public string collection_date { get; set; }
        [Display(Name = "Indicator")]
        public string indicator { get; set; }
        [Display(Name = "Value")]
        public float value { get; set; }
        [Display(Name = "Unit")]
        public string unit { get; set; }

        public regions Region { get; set; }
    }
}
