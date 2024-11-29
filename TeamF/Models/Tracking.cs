using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamF.Models
{
    public class Tracking
    {
        [Key]
        public int TrackingID { get; set; }

        [Required]
        public int PackageID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } // Picked Up, In Transit, Delivered

        [MaxLength(255)]
        public string Location { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        [ForeignKey("PackageID")]
        public Package Package { get; set; }
    }
}
