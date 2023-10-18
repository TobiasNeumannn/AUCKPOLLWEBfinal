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
        [DataType(DataType.Date)] // Data annotation that makes it so the user only had to enter a date, not date and time
        public DateTime collection_date { get; set; }
        [Display(Name = "Value")]
        [Range(maximum: 1000, minimum: 0)] // Specifies the boundaries - field doesn't accept an integer greater than 1000 or lesser than 0
        public float value { get; set; }
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 10, MinimumLength = 2)] // Specifies the boundaries - field doesn't accept a string greater than 1000 or fewer than 0 characters
        public string unit { get; set; }

        public regions Region { get; set; } // Connects this table to the regions table, so it knows that the field 'regionID' is the same field as the one in the regions table
    }
}
