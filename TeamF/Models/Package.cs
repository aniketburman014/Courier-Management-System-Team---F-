using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamF.Models
{
    public class Package
    {
        [Key]
        public int PackageID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(255)]
        public string PickupAddress { get; set; }

        [Required]
        [MaxLength(255)]
        public string DeliveryAddress { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Weight { get; set; }


        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        public int? CourierID { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CustomerID")]
        public User Customer { get; set; } 

        [ForeignKey("CourierID")]
        public Courier Courier { get; set; }
    }
}
