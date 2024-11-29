using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamF.Models
{
    public class DeliveryDetails
    {
        [Key]
        public int DeliveryID { get; set; }

        [Required]
        public int PackageID { get; set; }

        [Required]
        public DateTime DeliveredAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string ReceiverName { get; set; }

        [ForeignKey("PackageID")]
        public Package Package { get; set; }
    }
}
